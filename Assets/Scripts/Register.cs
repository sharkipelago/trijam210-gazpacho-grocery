using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{

	[SerializeField] ListManager listManager;
	[SerializeField] Timer timer;
	[SerializeField] GameManager gameManager;
	[SerializeField] DistractingShopper[] shoppers;
 
	int completedLists = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameManager.GameOver) { return; }

		if (collision.TryGetComponent(out PlayerController player))
		{
			if (listManager.CheckListComplete())
			{
				Debug.Log("COMPLETED!");
				completedLists++;
				timer.AddCompletionBonus();
				listManager.MakeHarderList();
				UpdateShoppersDesiredGrocery();
				return;
			}

			Debug.Log("Still Missing some stuff ..");

		}
	}

	private void UpdateShoppersDesiredGrocery()
	{
		foreach(DistractingShopper shopper in shoppers)
		{
			shopper.OnPlayerCompletesList();
		}
	}

}
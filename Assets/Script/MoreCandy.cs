using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoreCandy : MonoBehaviour
{
    #region Variables
    public GameObject[] candyTemplate; //Prefab

    public TMP_Text candyCountText;     //displays the candy count
    private int candyCount = 0;         //keeps track of the number of candy

    public TMP_Text candyMultiplierText;     //displays the candy multiplier
    public int candyMultiplier = 1;         //keeps track of the candy multiplier

    public TMP_Text costMultiplierText;     //displays the cost of using the multiplier

    public int candyIndex = 1;      //keeps track of the candy colour
    #endregion

    #region Unity Event Functions
    public void Start()
    {
        UpdateUI();
    }
    #endregion

    #region My Functions
    //This function is triggered when the more button is pressed and it increases the candy count and drops a candy.
    public void More()
    {
        for (int loop = 0; loop < candyMultiplier; loop++)
        {
            candyCount++;       //increment the candy count by 1
            UpdateUI();
            float randomX = Random.Range(-0.1f, 0.1f);  //creating a random number so the candies don't stack on top of each other
            Instantiate(candyTemplate[candyIndex], new Vector2(randomX, 6f), Quaternion.identity);     //this creates an new instance of the object
        }
    }
    
    //This function is called when the Faster button is pressed and it increases the number of candy you get
    public void Faster()
    {
        if (candyCount >= 10 * candyMultiplier)        //checks to see if there's enough
        {
            candyCount -= 10 * candyMultiplier;        
            candyMultiplier++;
            UpdateUI();
        }
    }

    //This function is called when the Change button is pressed and it changes the colour of the candy
    public void Change()
    {
        if(candyIndex < 6)   //Checks to see if the candy is within range of the array
        {
            candyIndex++; //changes the candy colour
        }
        else
        {
            candyIndex = 0;
        }
    }

    //This function is called within this script to Update the UI
    public void UpdateUI()
    {
        candyCountText.text = "Candy Count: " + candyCount.ToString();  //displays the candy count
        costMultiplierText.text = "Faster Cost: " + (10 * candyMultiplier).ToString();  //displays the cost to multiply
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// a number guessing game that implements binary search to guess the players number from 0-1,000,000
public class GuessGameController : MonoBehaviour
{
    //
    private int minNumber = 0;
    private int maxNumber = 1000000;
    private int curGuess, numberGuesses;
    public Button correctButton, higherButton, lowerButton, resetButton;
    public TextMeshProUGUI numGuesses, guessNumber;
    private Color defaultTextColor = new Color32(203, 159, 221, 255);
    private Color correctTextColor = new Color32(69, 180, 13, 255);
    void Start() {
        //attach buttonClick events
        correctButton.onClick.AddListener(onClickCorrect);
        higherButton.onClick.AddListener(onClickHigher);
        lowerButton.onClick.AddListener(onClickLower);
        resetButton.onClick.AddListener(onClickReset);

        
        
        initialState();
    }
    // initial game state
    void initialState () {
        //set color of text
        guessNumber.color = defaultTextColor;
        //set  min max range
        minNumber = 0;
        maxNumber = 1000000;

        //set number guess and make first guess
        numberGuesses = 0;
        setGuess(getHalfway(minNumber, maxNumber));
        //enable buttons
        enableGameButtons();
    }
    
    //increases numGuess count and sets text
    void incrementNumGuesses() {
        numberGuesses++;
        numGuesses.SetText(numberGuesses.ToString());
    }

    // enable or disable buttons
    void disableGameButtons(){
        higherButton.interactable = false;
        lowerButton.interactable  = false;
        correctButton.interactable = false;
    }
    void enableGameButtons(){
        higherButton.interactable = true;
        lowerButton.interactable  = true;
        correctButton.interactable = true;
    }

    // sets current guess text and local var
    void setGuess(int guess) {
        curGuess = guess;
        incrementNumGuesses();
        guessNumber.SetText(guess.ToString());
    }

    void onClickCorrect() {
        Debug.Log("correct");
        //make guess green
        guessNumber.color = correctTextColor;
        //prevent further guesses
        disableGameButtons();
    }

    void onClickReset() {
        //reset to inital state
        guessNumber.color = defaultTextColor;
        minNumber = 0;
        maxNumber = 1000000;
        numberGuesses = 0;
        setGuess(getHalfway(minNumber, maxNumber));
        enableGameButtons();
    }
    void onClickHigher() {
        //get half way from curGuess to max Guess;
        minNumber = curGuess + 1;
        int nextGuess = getHalfway(minNumber, maxNumber);
        setGuess(nextGuess);
    }
    void onClickLower() {
        Debug.Log("lower");
        maxNumber = curGuess - 1;
        int nextGuess = getHalfway(minNumber, maxNumber);
        setGuess(nextGuess);
    }

    int getHalfway(int low, int high) {
        float avg =  ((float) (high - low) / 2f) + 0.5f;
        int guess = low + (int) Mathf.Floor(avg);
        Debug.Log(guess);
        return guess;
    }
}

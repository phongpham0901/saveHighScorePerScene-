using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static GameManager instance;

    [SerializeField] float Score;
    [SerializeField] float highScore;

    [SerializeField] Text textScore;
    [SerializeField] Text textHighScore;
    private static int currentLevel = 0;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void increment()
    {
        Score++;
    }
    
    public void loadScene()
    {
        currentLevel++; // T?ng s? th? t? c?a màn lên 1
        if (currentLevel > 2) // N?u v??t quá màn th? 10, quay l?i màn ??u tiên
        {
            currentLevel = 0;
        }
        SceneManager.LoadScene(currentLevel); // Load scene ti?p theo
    }

    

    void Start()
    {    
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        highScore = PlayerPrefs.GetFloat("highScore" + currentSceneIndex);
        Debug.Log("Current scene index: " + currentSceneIndex);

    }

    // Update is called once per frame
    void Update()
    {

        textScore.text = Score.ToString();
        textHighScore.text = highScore.ToString();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (Score > highScore)
        {
            PlayerPrefs.SetFloat("highScore" + currentSceneIndex, Score);
        }
        
    }
}

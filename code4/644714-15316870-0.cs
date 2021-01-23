    public class Gameboard
    {
        ...
        public Gameboard(int numberofButtons, Form1 mainForm) //Constructor method that is referencing the App.config for the dimensions value to make the board
        {
            ... // init all buttons
            // for example
            for (int i = 0; i<buttonArray.Length; i++)
            {
                mainForm.Controls.Add(buttonArray[i]);
            }
        }
    }

    public Gameboard(int numberofButtons) //Constructor method that is referencing the App.config for the dimensions value to make the board
        {
            if (numberofButtons <= 0) 
                throw new ArgumentOutOfRangeException("Invalid Grid"); //throws an exception for an invalid grid size if dimensions is equal to or less than zero
            buttonArray = new Button[numberofButtons]; //creating an array the size of numberofButtons which is the dimensions value from App.config
            Font font = new Font("Times New Roman", 36.0f); //creates an instance of the Font class
            int sqrtY = (int) Math.Sqrt(numberofButtons);
            int z = 0; //Counter for array
            //Create the buttons for the form
            //Adds the buttons to the form first with null values then changes the .Text to ""
            for (int x = 0; x < sqrtY; x++)
            {
                for (int y = 0; y < sqrtY; y++)
                {
                    buttonArray[z] = new Button();
                    buttonArray[z].Font = font;
                    buttonArray[z].Size = new System.Drawing.Size(100, 100);
                    buttonArray[z].Location = new System.Drawing.Point(100*y, 100*x);
                    buttonArray[z].Click += new EventHandler(button_click);
                    z++; 
                }
            }//At the end of this loop, buttonArray contains a number of buttons equal to Dimensions all of which have a .Text property of ""
        }

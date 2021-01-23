            //Variables
            int rowSize = 8;
            int colSize = 8;
            //Calculation
            for (int row = 0; row < rowSize; row++) //Loop throw ROW's
            {
                for (int col = 0; col < colSize; col++) //Loop throw COL's
                {
                    if ((row + col) % 2 == 0) //Check if cells is EVEN
                    {
                        Console.Write("X"); //White square
                    }
                    else
                    {
                        Console.Write("O"); //Black square
                    }
                }
                Console.WriteLine(); //Switch to a new line

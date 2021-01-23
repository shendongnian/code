    using System;
    class system
    {
        static void Main(string[] args)
        {
                int rows = 5;
                int columns = 5;
    
            
                int[,] ProcArea = new int[rows, columns];
    
                RandomFill(out ProcArea, rows, columns);
    
            // display new matrix in 5x5 form
                int i, j;
                for (i = 0; i < rows; i++)
                {
                    for (j = 0; j < columns; j++)
                        Console.Write("{0}\t", ProcArea[i, j]);
                    Console.WriteLine();
                }
                Console.ReadKey();
    
        }
    
        public static void RandomFill(out int[,] array, int rows, int columns)
        {
    
            array = new int[rows, columns];
    
    
            Random rand = new Random();
            //Fill randomly
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (rand.NextDouble() < 0.55)
                    {
                        array[r, c] = 1;
                    }
                    else
                    {
                        array[r, c] = 0;
                    }
                }
            }
        }
    }

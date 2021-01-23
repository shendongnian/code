                headCount = 0, tailCount = 0;
            Random tossResult = new Random();
            do
            {
                Console.Write("Enter integer number (>=2) coin tosses or 0 to Exit: ");
                if (!int.TryParse(Console.ReadLine(), out nnOfTosses))
                {
                    Console.Write("Invalid input");
                }
                else
                {
                    //***//////////////////
                    // To assign a random number to each element
                    const int ROWS = 3;
                    double[] scores = new double[ROWS];
                    Random rn = new Random();
                    // Populate 2D array with random values
                    for (int row = 0; row < ROWS; row++)
                    {
                        scores[row] = rn.NextDouble();
                    }
                    //***//////////////////////////
                    for (int i = 0; i < nnOfTosses; i++)
                    {
                        double[] tossResult = new double[i];
                        tossResult[i]= tossResult.nextDouble();
                    }
                    Console.Write("Number of Coin Tosses = " + nnOfTosses);
                    Console.Write("Fraction of Heads = ");
                    Console.Write("Fraction of Tails = ");
                    Console.Write("Longest run is ");
                }
            } while (nnOfTosses != 0);
            Console.ReadLine();

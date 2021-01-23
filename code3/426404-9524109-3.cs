    ArrayList guesses = new ArrayList(); //This is the ArrayList        
        int position = 0;
        if (guesses.Count < 4)
        {
            for (int y = 0; y < guesses.Count; y++)
            {
                Console.Out.Write(guesses[y]);
            }
        }
        else
        {
            for (int i = 1; i <= guesses.Count; i++)
            {
                if (i%4 == 0)
                {
                    Console.Out.WriteLine(string.Format("{0}{1}{2}{3}", guesses[i - 4], guesses[i - 3],
                                                        guesses[i - 2], guesses[i - 1]));
                    position = i - 1;
                }
                else
                {
                    if (i == guesses.Count)
                    {
                        for (int j = position - 1; j > 0; j--)
                        {
                            Console.Out.Write(guesses[i - j]);
                        }
                    }
                }
            }
    
        }

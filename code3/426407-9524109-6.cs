    ArrayList guesses = new ArrayList(); //This is the ArrayList
        // Four or more
        guesses.Add(1); guesses.Add(2);
        guesses.Add(3);guesses.Add(4);
        guesses.Add(5); guesses.Add(6); guesses.Add(7);guesses.Add(8); guesses.Add(9);
        //Uncomment-Me for less than four inputs
        //guesses.Add(1); guesses.Add(2);
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
                    position = i;
                }
                else
                {
                    if (i == guesses.Count)
                    {
                        for (int j = position; j < i; j++)
                        {
                            Console.Out.Write(guesses[j]);
                        }
                    }
                }
            }
    
        }

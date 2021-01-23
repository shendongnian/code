        int total = 1,
                low = 0,
                high = 0;
            int ranNum1,
                guess;
            string guessStr;
            Random ranNumGen = new Random();
            ranNum1 = ranNumGen.Next(1, 10);
            Console.Write("Enter your guess >> ");
            guessStr = Console.ReadLine();
            guess = Convert.ToInt16(guessStr);
            while (guess != ranNum1 )
            {
                while (guess < ranNum1)
                {
                    Console.WriteLine("Your guess is to low, try again.");
                    Console.Write("\nEnter your guess >> ");
                    guessStr = Console.ReadLine();
                    guess = Convert.ToInt16(guessStr);
                    ++total;
                    ++low;
                }
                while (guess > ranNum1)
                {
                    Console.WriteLine("Your guess is to high, try again.");
                    Console.Write("\nEnter your guess >> ");
                    guessStr = Console.ReadLine();
                    guess = Convert.ToInt16(guessStr);
                    ++total;
                    ++high;
                }
            }
            //total = low + high;
            Console.WriteLine("It took you {0} guesses to correctly guess {1}", total, ranNum1);

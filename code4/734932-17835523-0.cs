            List<string> words = new List<string>();
            int tries = 0;
            Random rand = new Random();
            int randomword = rand.Next(1, 5);
            string word = "";
            Console.WriteLine("Please Enter 5 Words into the System");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                words.Add(Console.ReadLine());
                Console.Clear();
            }
            Console.WriteLine("For Display Purposes. Here are Your 5 Words");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Now Guess The word given Below");
            Console.WriteLine();
            switch (randomword)
            {
                case 1:
                    //Gets the List index 0 - 1st word in the list
                    word = words[0];
                    tries = word.Length;
                    break;
                case 2:
                    word = words[1];
                    tries = word.Length;
                    break;
                case 3:
                    word = words[2];
                    tries = word.Length;
                    break;
                case 4:
                    word = words[3];
                    tries = word.Length;
                    break;
                case 5:
                    word = words[4];
                    tries = word.Length;
                    break;
                default:
                    break;
            }
            //Default + addition to the Length
            tries += 2;
            Console.WriteLine();
            Console.WriteLine("You Have {0} + tries", tries);
            List<char> guesses = new List<char>();
            string guessedWord = "";
            for(int i=0;i<word.Length;i++)
            {
                guessedWord += "_";
            }
            //Works for the 1st Guess
            do
            {
                char guess = char.Parse(Console.ReadLine());
                if (word.Contains(guess))
                {
                    guesses.Add(guess);
                }
                foreach (char storedGuess in guesses)
                {
                    if(word.Contains(storedGuess))
                    {
                        int index = word.IndexOf(storedGuess);
                        while(index > -1)
                        {
                            StringBuilder sb = new StringBuilder(guessedWord);
                            sb[index] = storedGuess;
                            guessedWord = sb.ToString();
                            index = word.IndexOf(storedGuess, index+1);
                        }
                    }
                }
                Console.WriteLine(guessedWord);
            }
            while (guessedWord.Contains("_"));
            Console.ReadKey();

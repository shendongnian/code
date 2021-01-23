    static void Main(string[] args)
    {
    
        string[] words = new string[] { "Apple", "Banana", "Pear", "Pineapple", "Melon"};
        Random random = new Random();
    
        string wordToGuess = words[random.Next(5)].ToLower();
        char[] currentLetters = new char[wordToGuess.Length];
        for (int i = 0; i < currentLetters.Length; i++) currentLetters[i] = '_';
        int numTries = currentLetters.Length + 1;
        bool hasWon = false;
        do
        {
            string input = Console.ReadLine().ToLower();
            if (input.Length == 1) //guess a letter
            {
                char inputChar = input[0];
                for (int i = 0; i < currentLetters.Length; i++)
                {
                    if (wordToGuess[i] == inputChar)
                    {
                        currentLetters[i] = inputChar;
                    }
                }
                if (!currentLetters.Contains('_'))
                {
                    hasWon = true;
                }
                else
                {
                    Console.WriteLine(new string(currentLetters));
                }
            }
            else
            {
                if (input == wordToGuess)
                {
                    hasWon = true;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                    Console.WriteLine(new string(currentLetters));
                }
            }
    
            numTries--;
    
        } while (new string(currentLetters) != wordToGuess && numTries > 0 && !hasWon);
    
        if (hasWon)
        {
            Console.WriteLine("Congratulations, you guessed correctly.");
        }
        else
        {
            Console.WriteLine("Too bad! Out of tries");
        }
    }

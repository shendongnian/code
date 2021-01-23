    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Enter Morse Code: ");
            string morseInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(morseInput))
            {
                // Empty or consists only of white-space characters
                break;
            }
            morseInput = morseInput.Replace(" ", "");
            bool isValid = Regex.IsMatch(morseInput, @"^[-.]+$");
            if (isValid)
            {
                Console.WriteLine("All permutations:");
                Console.WriteLine();
                var nexts = new List<string>(Permutations(morseInput));
                foreach (string next in nexts)
                    Write(next);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Format of morse must be only dots and dashes.");
                Console.WriteLine("Parameter name: {0}", morseInput);
            }
        }
        while (true);
    }

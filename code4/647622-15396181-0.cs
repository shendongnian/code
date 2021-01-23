    class Program
    {
        readonly string[] wordList = { 
                            "Baseball", "Tackle", "Dubstep", "Ignorance", "Limitation", "Sausage",
                            "Destruction", "Patriot", "Computing", "Assembly", "Coding", "Hackers",
                            "Football", "Downward"
                        };
        static void Main(string[] args)
        {
            int guessRemain = 7;
            int wordSel = GenerateRandom();
            Program o = new Program();
            List<char> wordChar = o.wordList[wordSel].ToLower().ToList();
            int MAX_BUF = wordChar.Count;
            Console.WriteLine("\nHANGMAN v 1.0\n\n\n\n");
            char userInput = PromptUserEntry();
            List<char> solution = ScanForMatchingLetter(wordChar, MAX_BUF, userInput);
            Console.Read();
        }
        private static List<char> ScanForMatchingLetter(List<char> wordChar, int MAX_BUF, char userInput)
        {
            List<char> solution = new char[MAX_BUF].ToList();
            for (int i = 0; i < MAX_BUF; ++i)
            {
                if (userInput == wordChar[i])
                {
                    solution[i] = userInput;
                }
            }
            return solution;
        }
        private static char PromptUserEntry()
        {
            Console.WriteLine("Pick a letter:");
            char userInput = Console.ReadLine()[0];
            return userInput;
        }
        private static void DisplayGuessLetterLine(List<char> solution)
        {
            Console.Write(solution);
        }
        private static int GenerateRandom()
        {
            Random randNum = new Random();
            int wordSel = randNum.Next(0, 13);
            return wordSel;
        }
    }

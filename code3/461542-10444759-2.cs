    class Program
    {
        static void Main(string[] args)
        {
            string input = "Stack Overflow";
            if (!string.IsNullOrEmpty(input))
            {
                Hangman h = new Hangman(input);
                string letter = Console.ReadLine();
                while (!string.IsNullOrEmpty(letter))
                {
                    h.CheckLetter(letter);
                    letter = Console.ReadLine();
                }
            }
        }
    }

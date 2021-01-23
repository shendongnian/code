    public class Hangman
    {
        public List<string> InvalidLetters { get; private set; }
        private string input;
        public Hangman(string input)
        {
            InvalidLetters = new List<string>();
            this.input = input;
        }
        public void CheckLetter(string letter)
        {
            if (!Regex.IsMatch(input, letter, RegexOptions.IgnoreCase))
            {
                InvalidLetters.Add(letter);
                Console.WriteLine("Letter " + letter + " does not appear in the string.");
            }
            else
            {
                MatchCollection coll = Regex.Matches(input, letter, RegexOptions.IgnoreCase);
                Console.WriteLine("Letter " + letter + " appears in the following locations:");
                foreach (Match m in coll)
                {
                    Console.WriteLine(m.Index);
                }
            }
        }
    }

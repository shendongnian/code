        public string CorrectWord = null;
        public string InputWord; // the word the uis
        public int points;
        public string[] Wordarray = new string[] { "radar", "andar", "raggar", "rapar", "raser", "rastar", "rikas" };
        public string getRandomWord()
        {
            Random ran = new Random();
            return Wordarray[(ran.Next(0, Wordarray.Length - 1))];
        }
        public void Newgame()
        {
        }
        public void CheckWords(string name)
        {
            char[] charInputWord = name.ToCharArray();
            CorrectWord = getRandomWord(); // store the random word in a string
            Console.WriteLine("Random Word " + CorrectWord);
            Console.WriteLine("User Word " + name);
            char[] charCorrectWord = CorrectWord.ToCharArray();
            for (int i = 0; i < charInputWord.Length; i++)
            {
                if (charInputWord[i] == charCorrectWord[i])
                    Console.WriteLine("Letter #" + (i + 1).ToString() + " was correct!");
                else
                    break;
            }
        }
    }
    class Program
        {
            static void Main(string[] args)
            {
                Game ab = new Game();
                ab.CheckWords("raser");
    
                Console.ReadLine();
            }
        }

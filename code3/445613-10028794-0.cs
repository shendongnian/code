        static void Main(string[] args)
        {
            string word = args[0];
            string label = string.Empty;
            label = new Regex(" ").Replace(word, " / ");
            label = new Regex("([a-zA-z0-9])").Replace(label, "_ ");            
            Console.WriteLine(word);
            Console.WriteLine(label);
            Console.ReadLine();
        }

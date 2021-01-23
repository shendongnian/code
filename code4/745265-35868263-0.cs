        static void Main(string[] args)
        {
            Char[] ch;
            Console.WriteLine("Create a sentence");
            String letters = Console.ReadLine().Replace(" ", "").ToUpper();
            ch = letters.ToCharArray();
            int vowelCounter = 0;
            int consonantCounter = 0;
           for(int x = 0; x < letters.Length; x++)
            {
                if(ch[x].ToString().Equals("A") || ch[x].ToString().Equals("E") || ch[x].ToString().Equals("I") || ch[x].ToString().Equals("O") || ch[x].ToString().Equals("U"))
                {
                    vowelCounter++;
                }
                else
                {
                    consonantCounter ++;
                }
            }
            System.Console.WriteLine("Vowels counted : " + vowelCounter);
            System.Console.WriteLine("Consonants counted : " + consonantCounter);

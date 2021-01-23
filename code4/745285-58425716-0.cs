    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] consonants = new string[] { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };
            string[] vowels = new string[] { "a", "e", "i", "o", "u", "y", "ee", "aa","ij", "oe" };
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Length word: ");
                int Length = Convert.ToInt32(Console.ReadLine());
                
                Random rnd = new Random();
                int a;
                int goal = Length;
                for (int i = 0; i != goal; i++)
                {
                    a = rnd.Next(1, consonants.Length);
                    if (i % 2 == 0)
                    {
                        a = rnd.Next(1, consonants.Length);
                        Console.Write(consonants[a]);
                    }
                    Thread.Sleep(10);
                    if (i % 2 != 0)
                    {
                        a = rnd.Next(1, vowels.Length);
                        Console.Write(vowels[a]);
                    }
                    Thread.Sleep(200);
                }
            }
        }
    }
}

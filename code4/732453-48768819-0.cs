    private static void Vowel(string value)
        {
            int vowel = 0;
            foreach (var x in value.ToLower())
            {
                if (x.Equals('a') || x.Equals('e') || x.Equals('i') || x.Equals('o') || x.Equals('u'))
                {
                    vowel += 1;
                }
            }
            Console.WriteLine( vowel + " number of vowels");
        }
        private static void Consonant(string value)
        {
            int cont = 0;
            foreach (var x in value.ToLower())
            {
                if (x > 'a' && x <= 'd' || x > 'e' && x < 'i' || x > 'j' && x < 'o' || x >= 'p' && x < 'u' || x > 'v' && x < 'z')
                {
                    cont += 1;
                }
            }
            Console.WriteLine(cont + " number of consonant");
        }

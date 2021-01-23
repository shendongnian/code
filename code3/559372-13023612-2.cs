        public void RandomChars()
        {
            Random random = new Random();
            String consonants = "BCDFGHJKLMNPQRSTVWXYZ";
            String vowels = "AEIOU";
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                char theChar;
                if (i % 5 == 0)
                {
                    theChar = vowels[random.Next(vowels.Length)];
                }
                else
                {
                    theChar = consonants[random.Next(consonants.Length)];
                }
                result.Append(theChar);
            }
            Console.WriteLine(result.ToString());
        }

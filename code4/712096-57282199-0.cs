        public static string GenerateBitKey(int letterCount = 44)
        {
            // Get the number of words and letters per word.
            int num_letters = letterCount;
            // Make an array of the letters we will use.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrsruvwxyz+".ToCharArray();
            int lettersLength =  letters.Length;
            // Make a word.
            string word = "";
            //Use Cryptography to generate random numbers rather than Psuedo Random Rand
            // Deliberate overkill here
            byte[] randomBytes = new byte[num_letters*256];
            using (System.Security.Cryptography.RNGCryptoServiceProvider rngCsp = new
                        System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(randomBytes);
            }
            // Truncate the set of random bytes to being in range 0 .. (lettersLength-1)
            // Nb Using mod of randomBytes will reduce entropy of the set
            List<int> rands = new List<int>();
            foreach (var x in randomBytes)
            {
                if (x < lettersLength)
                    rands.Add((int)x);
            }
            // Perhaps should use smaller set of randomBytes and check have required number here. 
            // .... Repeat (adding on new values) to  list until have required number.
            int[] randsArray = rands.ToArray();
            // Get random selection of characters from letters
            for (int j = 0; j < num_letters; j++)
            {
                int letter_num = randsArray[j];
                // Append the letter.
                word += letters[letter_num];
            }
            return word;
        }

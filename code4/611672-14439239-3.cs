        public int LetterCodeToInt(String LetterCode)
        {
            //fill up whitespaces in front.
            String s = LetterCode.PadLeft(3, '_').ToUpper();
            int value = 0;
            int k = s.Length -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '_')
                {
                    //ASCII "A" is 65, subtract 64 to make it "1" 
                    value += (((int)s[i]) - 64) * Convert.ToInt32(Math.Pow(26, k));
                }
                k--;
            }
            return value;
        }

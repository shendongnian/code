        public static string RemoveNonDigits(string s)
        {
            string newS = "";
            if (s.Length == 0) return newS;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsNumber(s[i]))
                {
                    newS += "";
                }
                else newS += s[i];
            }
            return newS;
        }

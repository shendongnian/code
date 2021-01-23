        public static string RemoveNonDigits(string s)
        {
            string newS = "";
            if (s.Length == 0) return newS;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]) || s[i] == '.')
                     newS += s[i];
                else if (!Char.IsDigit(s[i]))
                {
                    newS += "";
                }
                return newS;
            }

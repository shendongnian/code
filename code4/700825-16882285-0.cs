        public string GetString(string s, int substringLen, int skipCount)
        {
            string newString = "";
            for (int i = 0; i < s.Length; i += skipCount)
            {
                for (int j = 0; j < substringLen && i < s.Length; j++)
                {
                    newString += s[i++];
                }
            }
            return newString;
        }

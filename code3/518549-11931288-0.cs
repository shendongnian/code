        private Dictionary<char, string> characterLookup = new Dictionary<char, string>();
        public string[] GetSentences(string password)
        {
            string[] sentences = new string[password.Length];
            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];
                if (char.IsLetterOrDigit(currentChar))
                {
                    sentences[i] = string.Format("{0} {1} as in {2}",
                        char.IsLower(currentChar) ? "Lower" : "Upper",
                        currentChar.ToUpper(),
                        characterLookup[currentChar.ToLower()]);
                }
            }
            return sentences;
        }

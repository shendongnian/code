        public string testmethod(string str1, string str2)
        {
            string result = str1;
            foreach (char character in str2.ToCharArray())
            {
                result = result.Replace(character.ToString(), "");
            }
            return result;
        }

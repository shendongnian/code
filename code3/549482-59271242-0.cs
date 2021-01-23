        public static List<int> GetSubstringLocations(string text, string searchsequence)
        {
            try
            {
                List<int> foundIndexes = new List<int> { };
                int i = 0;
                while (i < text.Length)
                {
                    int cindex = text.IndexOf(searchsequence, i);
                    if (cindex >= 0)
                    {
                        foundIndexes.Add(cindex);
                        i = cindex;
                    }
                    i++;
                }
                return foundIndexes;
            }
            catch (Exception ex) { }
            return new List<int> { };
        }

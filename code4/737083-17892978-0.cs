        private int stringMatches(string textToQuery, IReadOnlyList<string> stringsToFind)
        {
            int count = 0, stringCount = stringsToFind.Count();
            for (int i = 0; i < stringCount; i++)
            {
                int currentIndex = 0;
                string stringToFind = stringsToFind[i];
                while ((currentIndex = textToQuery.IndexOf(stringToFind, currentIndex, StringComparison.Ordinal)) != -1)
                {
                    currentIndex++;
                    count++;
                }
            }
            return count;
        }

        List<string> WordCombinations(string phrase)
        {
            List<string> combinations = new List<string>();
            string[] words = phrase.Split();
            for (int wordCount = 2; wordCount <= words.Length - 1; wordCount++)
            {
                for (int startIndex = 0; startIndex + wordCount <= words.Length; startIndex++)
                {
                    combinations.Add(string.Join(" ", words.Skip(startIndex).Take(wordCount)));
                }
            }
            return combinations;
        }

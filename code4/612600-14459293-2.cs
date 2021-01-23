        List<string> WordCombinations(string phrase)
        {
            List<string> combinations = new List<string>();
            string[] words = phrase.Split();
            // We want all 2 word combinations, then 3, then 4, ...
            for (int take = 2; take < words.Length; take++)
            {
                // Start with the first word, then second, then ...
                for (int skip = 0; skip + take <= words.Length; skip++)
                {
                    combinations.Add(string.Join(" ", words.Skip(skip).Take(take).ToArray()));
                }
            }
            return combinations;
        }

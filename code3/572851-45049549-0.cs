            "which", 
            "wristwatches", 
            "are", 
            "swiss", 
            "wristwatches"
        };
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
			
			// Insert a word in the dictionary if it exits, otherwise increment 
            //the count of the word
            for (int i = 0; i < words.Length; i++)
            {
                try
                {
                    wordCount.Add(words[i], 1);
                }
                catch (Exception)
                {
                    wordCount[words[i]] += 1;
                }
            }
			// display word and it's corresponding word count
            foreach (var item in wordCount)
            {
                Console.WriteLine ("{0}   {1}", item.Key, item.Value);
            }

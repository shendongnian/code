        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word] += 1; 
            }
            else
            {
                dictionary.Add(word,1);
            }
        }

    Dictionary d = new Dictionary<string, int>();
    
    foreach (string word in wordList)
    {
        if (d.ContainsKey(word))
        {
           d[word]++;
        }
        else
        {
           d[word] = 1;
        }
    }

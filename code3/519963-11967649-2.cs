        Dictionary<string, int> dic = new Dictionary<string, int>()
        foreach (string word in words)
        {
            if (dic.ContainsKey(word))
            {
                dic[word] += 1; 
            }
            else
            {
                dic.Add(word,1);
            }
        }

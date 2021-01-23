        Dictionary<string, int> dic = new Dictionary<string, int>()
        foreach (string word in words)
        {
            if (dic.ContainsKey(word))
            {
                dic[word] = dic[word]++; 
            }
            else
            {
                dic.Add(word,1);
            }
        }

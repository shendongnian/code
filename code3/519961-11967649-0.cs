        Dictionary<string, int> dic = new Dictionary<string, int>()
        foreach (string word in words)
        {
            if (dic.cointains(word))
            {
                dic[word] = dic[word]++; 
            }
            else
            {
                dic.add(word,1);
            }
        }

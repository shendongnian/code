    foreach (List <string> catterms in _terms)
    {
		var newDict = new Dictionary<string, int>();
        for (int i = 0; i < catterms.Count; i++)
        {
            newDict.Add(catterms[i], i);
        }
        _wordsIndex.Add(newDict)
    }

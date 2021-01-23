    private Dictionary<string,int> GenerateTerms(string[] docs)
    {
        List<Dictionary<string, int>> combinedDictionaryList = new List<Dictionary<string, int>>();
        foreach (string str in docs)
        {
            //Add returned dictionaries to a list
            combinedDictionaryList.Add(ProcessDocument(str));
        }
        //return a single dictionary from list od dictionaries
        return combinedDictionaryList
                .SelectMany(dict=> dict)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(group => group.Key, group => group.Sum(value => value));
    }
    private Dictionary<string,int> ProcessDocument(string doc)
    {
        return doc.Split(' ')
                .GroupBy(word => word)
                .OrderByDescending(g => g.Count())
                .Take(1000)
                .ToDictionary(r => r.Key, r => r.Count());
    }

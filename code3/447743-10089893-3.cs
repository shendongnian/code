    var dictionary = new Dictionary<string, List<int>>();
    
    if (!dictionary.ContainsKey("foo"))
        dictionary.Add("foo", new List<int>());
    
    dictionary["foo"].Add(42);
    dictionary["foo"].AddRange(oneHundredInts);

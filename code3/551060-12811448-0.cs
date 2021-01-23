    Dictionary<string, double> dictionary = new Dictionary<string, double>();
    dictionary.Add("abc", 3);
    dictionary.Add("def", 1);
    dictionary.Add("ghi", 2);
    
    dictionary.OrderByDescending(x => x.Key);

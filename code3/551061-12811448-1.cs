    Dictionary<string, double> dictionary = new Dictionary<string, double>();
    dictionary.Add("abc", 3);
    dictionary.Add("def", 1);
    dictionary.Add("ghi", 2);
    
    var sortedDict = dictionary.OrderByDescending(x => x.Value);
    double[] values = sortedDict.Select(x => x.Value).ToArray();
    List<string> strs = sortedDict.Select(x => x.Key).ToList();

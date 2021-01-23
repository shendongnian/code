    // source dictionary
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    
    // target dictionary
    Dictionary<string, List<string>> target = new Dictionary<string, List<string>>();
    // using LINQ extension methods
    dict.ToList().ForEach(i =>
    {
        List<string> temp = i.Value.Select(x => x.Trim()).ToList();
        target.Add(i.Key, temp);
    });

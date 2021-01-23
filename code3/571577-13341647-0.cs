    List<string> names = new List<string>(); // this is the main list with strings
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    
    foreach (string name in names)
    {
        if (!dict.ContainsKey(name))
            dict.Add(name, new List<string>());
        dict[name].Add("another one bytes the dust :)");
    }  

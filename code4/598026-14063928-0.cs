    SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
    dict.Add("Alpha", 10);
    dict.Add("Beta", 20);
    dict.Add("Zeta", 30);
    
    foreach(string key in dict.Keys.Reverse())
    {
       int avg = dict[key];
    }

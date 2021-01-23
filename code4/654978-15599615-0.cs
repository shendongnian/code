    var lists = new List<List<string>>();
    
    lists.Add(new List<string>(){"a","b"});
    lists.Add(new List<string>(){"b","2"});
    lists.Add(new List<string>(){"c","5"});
    lists.Add(new List<string>(){"d","7"});
    
    var t=lists.SelectMany(f=>f);
    
    t.Dump();

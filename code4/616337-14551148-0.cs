    var splits = lines.Select(l => l.Split('|'));
    var dict = new Dictionary<string,string>();
    foreach(var item in splits)
    {
       if(!dict.ContainsKey(item[0]))
           dict.Add(item[0], item[1]);
    }
    

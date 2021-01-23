    Dictionary<int,string> d = new Dictionary<int,string>();
    d.Add(1, "entries");
    d.Add(2, "images");
    d.Add(3, "views");
    d.Add(4, "images");
    d.Add(5, "results");
    d.Add(6, "images");
    d.Add(7, "entries");
    
    d.GroupBy(x => x.Value)
     .Where(x=>x.Count()>1)
     .SelectMany(x => x)
     .ToDictionary
     (
         x => x.Key,
         x=>x.Value
     );

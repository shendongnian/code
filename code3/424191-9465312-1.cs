    var set = new HashSet<int>(a);
    var z = new List<int>(Math.Min(set.Count, b.Count));
    foreach(int i in b)
    {
        if(set.Contains(i))
            a.Add(i);
    }

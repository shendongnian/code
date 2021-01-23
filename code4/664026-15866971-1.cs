    var list = new List<string> { "a", "a", "b", "b", "r", "t" };
    var distinct = new HashSet<string>();    
    var duplicates = new HashSet<string>();
    foreach (var s in list)
        if (!distinct.Add(s))
            duplicates.Add(s);
    // distinct == { "a", "b", "r", "t" }
    // duplicates == { "a", "b" }

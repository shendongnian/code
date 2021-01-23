    Dictionary<int, List<Properties>> dict = new Dictionary<int, List<Properties>>();
    dict[0] = ...;
    dict[1] = ...;
    dict[5] = ...;
    List<Properties> item5 = dict[5]; // This works if dict contains a key 5.
    List<Properties> item6 = null;
    // You might want to check whether the key is actually in the dictionary. Otherwise
    // you might get an exception
    if (dict.ContainsKey(6))
        item6 = dict[6];
    

    Dictionary<string, string> test = new Dictionary<string, string>();
    List<string> keys = test.Keys.ToList();
    foreach (string key in keys)
    {
        test[key] = "Some new content";
    }
    
    IEnumerable<string> newKeys = test.Keys.ToList().Except(keys);
    
    if(newKeys.Count() > 0)
        // Do it again or whatever.

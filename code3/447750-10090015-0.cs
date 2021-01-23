    void Add(string key, string val)
    {
        List<string> list;
        
        if (!dictionary.TryGetValue(someKey, out list))
        {
           values = new List<string>();
           dictionary.Add(key, list);
        }
        list.Add(val);
    }

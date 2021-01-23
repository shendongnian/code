    void AddOrUpdate(Dictionary<string, string> dict, string key, string value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = value;
        }
        else
        {
            dict.Add(key, value);
        }
    }
    
    //usage:
    AddOrUpdate(myDict, "some key here", "your value");

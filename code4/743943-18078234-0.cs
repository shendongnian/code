    addExtension(this Dictionary<string, object> dictionary, string key, object value)
    {
        dictionary.Add(key, value);
        
        if(dictionary.Count == 50)
            dictionary.Remove(dictionary.First().Key);     
    }

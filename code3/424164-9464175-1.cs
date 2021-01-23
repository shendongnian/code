    private List<object> GetValuesFromDictionaryUsingKeys(Dictionary<string, object> dictionary, List<string> keys)
    {
        List<object> nList = new List<object>();
    
        foreach (string sKey in keys)
            if (dictionary.ContainsKey(sKey))
                nList.Add(dictionary[sKey]);
        
        return nList;         
    }

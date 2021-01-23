    private List<object> GetValuesFromDictionaryUsingKeys( Dictionary<string, object> dictionary, List<string> keys )
    {
        // My code here
        return keys.Intersect( dictionary.Keys )
                   .Select( k => dictionary[k] )
                   .ToList();     
    }

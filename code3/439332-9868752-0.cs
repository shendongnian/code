    public static void Dictionary<string, string[]> ToDictionary(this NameValueCollection collection) 
    {
        return collection.Cast<string>().ToDictionary(key => key, key => collection.GetValues(key));
    }
    var dictionary = collection.ToDictionary();
    if (dictionary.ContainsKey(key))
    {
       ...
    }

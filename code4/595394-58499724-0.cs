    public static IDictionary<string, TValue> ConvertToCaseInSensitive<TValue>(this IDictionary<string, TValue> dictionary)
    {
        var resultDictionary = new Dictionary<string, TValue>(StringComparer.InvariantCultureIgnoreCase);
        foreach (var (key, value) in dictionary)
        {
            resultDictionary.Add(key, value);
        }
        dictionary = resultDictionary;
        return dictionary;
    }

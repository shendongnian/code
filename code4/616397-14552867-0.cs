    public static string GetResourceInDictionary(ResourceDictionary dictionary, object item)
    {
        foreach (var key in dictionary.Keys)
            if (dictionary[key] == item)
                return key.ToString();
        return null;
    }

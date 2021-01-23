    public static string GetResourceInDictionary(ResourceDictionary dictionary, object item)
    {
        return (from DictionaryEntry key in dictionary
                where key.Value == item
                select key.Key.ToString()).FirstOrDefault();
    }

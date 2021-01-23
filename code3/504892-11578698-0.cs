    public static Dictionary<string, T> MyMethod<T>(object obj)
    {
        var stringDictionary = obj as Dictionary<string,T>;
        if (stringDictionary!= null)
        {
            return stringDictionary;
        }
        var baseDictionary = obj as IDictionary;
        if (baseDictionary != null)
        {
            var dictionary = new Dictionary<string, T>();
            foreach (DictionaryEntry keyValue in baseDictionary)
            {
                if (!(keyValue.Value is T))
                {
                    // value is not T. perhaps throw an exception
                    return null;
                }
                dictionary.Add((string) keyValue.Key, (T) keyValue.Value);
            }
            return dictionary;
        }
        // object is not a dictionary. perhaps throw an exception
        return null;
    }

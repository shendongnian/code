    public static Dictionary<TKey, TValue> MyMethod<TKey, TValue>(object obj)
    {
        if (obj is Dictionary<TKey, TValue> stringDictionary)
        {
            return stringDictionary;
        }
        if (obj is IDictionary baseDictionary)
        {
            var dictionary = new Dictionary<TKey, TValue>();
            foreach (DictionaryEntry keyValue in baseDictionary)
            {
                if (!(keyValue.Value is TValue))
                {
                    // value is not TKey. perhaps throw an exception
                    return null;
                }
                if (!(keyValue.Key is TKey))
                {
                    // value is not TValue. perhaps throw an exception
                    return null;
                }
                dictionary.Add((TKey)keyValue.Key, (TValue)keyValue.Value);
            }
            return dictionary;
        }
        // object is not a dictionary. perhaps throw an exception
        return null;
    }

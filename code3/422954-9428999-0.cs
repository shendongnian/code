    public static Dictionary<T, K> Build<T, K>(this Dictionary<T, K> dictionary, T key, K value)
    {
           dictionary[key] = value;
           return dictionary;
    }

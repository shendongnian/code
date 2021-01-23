    public static List<TValue> GetOrCreate<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key)
    {
        List<TValue> innerList;
        dictionary.TryGetValue(key, out innerList);
        if (innerList == null)
        {
            innerList = new List<TValue>();
            dictionary.Add(key, innerList);
        }
        return innerList;
    }

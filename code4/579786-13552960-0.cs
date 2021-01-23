    public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> target,
                                               List<TKey> keys)
    {
        var dict2 = new Dictionary<TKey, TValue>();
        foreach (var s in lst)
        {
            T val;
            if (dict.TryGetValue(s, out val))
            {
                dict2.Add(s, val);
            }
        }
        dict.Clear();
        foreach (var kvp in dict2)
        {
            dict.Add(kvp.Key, kvp.Value);
        }
    }

    public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> target,
                                               List<TKey> keys)
    {
        var tmp = new Dictionary<TKey, TValue>();
        foreach (var key in keys)
        {
            TValue val;
            if (target.TryGetValue(key, out val))
            {
                tmp.Add(key, val);
            }
        }
        target.Clear();
        foreach (var kvp in tmp)
        {
            target.Add(kvp.Key, kvp.Value);
        }
    }

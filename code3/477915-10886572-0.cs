    public static void MergeWith<TKey, TValue>(this Dictionary<TKey,TValue> dest, IDictionary<TKey, TValue> source)
    {
        foreach(var src in source)
        {
            dest[src.Key] = src.Value;
        }
    }
    //usage:
    dest.MergeWith(source);

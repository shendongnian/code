    public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> first
        , IDictionary<TKey, TValue> second
        , Func<TValue, TValue, TValue> aggregator)
    {
        if (second == null) return;
        if (first == null) throw new ArgumentNullException("first");
        foreach (var item in second)
        {
            if (!first.ContainsKey(item.Key))
            {
                first.Add(item.Key, item.Value);
            }
            else
            {
               first[item.Key] = aggregator(first[item.key], item.Value);
            }
        }
    }

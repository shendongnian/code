    public static Dictionary<TKey, List<T>> ToDictionary<T, TKey>(
        List<T> source, Func<T, TKey> keySelector)
    {
        Dictionary<TKey, List<T>> result = new Dictionary<TKey, List<T>>();
        foreach (T item in source)
        {
            TKey key = keySelector(item);
            if (!result.ContainsKey(key))
                result[key] = new List<T>();
            result[key].Add(item);
        }
        return result;
    }

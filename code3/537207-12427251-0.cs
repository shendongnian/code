    private static Dictionary<string, object> cache = new Dictionary<string, object>();
    public static IEnumerable<T> CachedSequence<T>(this IEnumerable<T> source, string key)
    {
        object value;
        if (cache.TryGetValue(key, out value))
        {
            List<T> list = (List<T>)value;
            foreach (T item in list)
            {
                yield return item;
            }
        }
        else
        {
            List<T> list = new List<T>();
            foreach (T item in source)
            {
                list.Add(item);
                yield return item;
            }
            cache.Add(key, list);
        }
    }
    public static void ClearCachedSequence(string key)
    {
        cache.Remove(key);
    }

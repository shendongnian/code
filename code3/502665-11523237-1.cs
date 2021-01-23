    public static Dictionary<int, T> ToDictionary<T>(this IEnumerable<T> source)
    {
        Dictionary<int, T> result = new Dictionary<int, T>();
        foreach(T item in source)
            result.Add(result.Count, item);
    }

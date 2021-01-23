    public static List<T> ToList<T>(this IEnumerable<T> source, int initialCapacity)
    {
        // parameter validation ommited for brevity
        var result = new List<T>(initialCapacity);
        foreach (T item in source)
        {
            result.Add(item);
        }
        return result;
    }

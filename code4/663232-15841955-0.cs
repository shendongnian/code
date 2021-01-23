    public static IEnumerable<T[]> Split<T>(this IEnumerable<T> source, T separator)
    {
        List<T> bucket = new List<T>();
        var comparer = Comparer<T>.Default;
        foreach (var item in source)
        {
            if (comparer.Compare(item, separator) != 0)
            {
                bucket.Add(item);
                continue;
            }
            if (bucket.Any())
            {
                yield return bucket.ToArray();
                bucket = new List<T>();
            }
        }
        if (bucket.Any())        
            yield return bucket.ToArray();        
    }

    public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> source)
    {
        bool shouldReturn = true;
        foreach (T item in source)
        {
            if (shouldReturn)
                yield return item;
            shouldReturn = !shouldReturn;
        }
    }
    
    public static Dictionary<T, T> MakeDictionary<T>(IEnumerable<T> source)
    {
        return source.EveryOther()
            .Zip(source.Skip(1).EveryOther(), (a, b) => new { Key = a, Value = b })
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

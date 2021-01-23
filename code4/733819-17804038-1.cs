    public static IEnumerable<IEnumerable<T>> GroupBySequence<T>(
        this IEnumerable<T> source, Func<T, bool> predicate)
    {
        var iterator = source.GetEnumerator();
        List<T> group = new List<T>();
        while (iterator.MoveNext())
        {
            if (predicate(iterator.Current))
            {
                group.Add(iterator.Current);
                continue;
            }            
            if (group.Any())
            {                    
                yield return group;
                group = new List<T>();
            }
        }
        if (group.Any())
            yield return group;
    }

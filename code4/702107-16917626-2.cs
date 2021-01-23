    public static IEnumerable<T> EnumerateAll<T>(params IEnumerable<T>[] lists)
    {
        var enumerators = lists.Select(l => l.GetEnumerator());
        while (enumerators.Any())
        {
            enumerators = enumerators.Where(e => e.MoveNext());
            foreach (var enumerator in enumerators)
                yield return enumerator.Current;           
        }
    }

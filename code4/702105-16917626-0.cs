    public static IEnumerable<T> EnumerateAll<T>(params IEnumerable<T>[] lists)
    {
        var enumerators = lists.Select(l => l.GetEnumerator());
        while (enumerators.Any())
        {
            foreach (var enumerator in enumerators)
            {
                if (enumerator.MoveNext())
                    yield return enumerator.Current;
            }
            enumerators = enumerators.Where(e => e.MoveNext());
        }
    }

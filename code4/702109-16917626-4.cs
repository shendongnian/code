    public static IEnumerable<T> EnumerateAll<T>(params IEnumerable<T>[] lists)
    {
        var enumerators = lists.Select(l => l.GetEnumerator()).ToList();
        while (enumerators.Any())
        {
            enumerators.RemoveAll(e => !e.MoveNext());
            foreach (var enumerator in enumerators)
                yield return enumerator.Current;
        }
    }

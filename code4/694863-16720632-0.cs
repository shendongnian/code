    IEnumerable<IEnumerable<T>> SublistSplit<T>(this IEnumerable<T> source)
    {
        if (source == null) return null;
    
        var list = source.ToArray();
        for (int i = 0; i < list.Count; i++)
        {
            yield return new ArraySegment<T>(list, 0, i);
        }
    }

    /// <summary>Splits an enumeration based on a predicate.</summary>
    /// <remarks>
    /// This method drops partitioning elements and does not remove empty entries.
    /// </remarks>
    public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> partitionBy,
        int count = -1)
    {
        int yielded = 0;
        var items = new List<TSource>();
        foreach (var item in source)
        {
            if (!partitionBy(item))
                items.Add(item);
            else
            {
                yield return items.ToArray();
                items.Clear();
                if (count > 0 && ++yielded == count) yield break;
            }
        }
        if (items.Count > 0) yield return items.ToArray();
    }

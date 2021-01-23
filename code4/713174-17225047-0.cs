    public static IEnumerable<TSource> AlternateGroups<TSource, TKey>(this IEnumerable<TSource> list, Func<TSource, TKey> keySelector)
    {
        var groups = list.GroupBy(keySelector).OrderByDescending(g => g.Count());
        var largestGroup = groups.First();
        var arrays = groups.Skip(1).Select(g => g.ToArray());
        var index = new int[arrays.Count()];
        foreach(var item in largestGroup)
        {
            yield return item;
            var i = 0;
            foreach(var a in arrays)
            {
                yield return a[index[i++]++ % a.Length];
            }
        }
    }

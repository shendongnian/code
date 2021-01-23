    public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, 
                                                         Func<T, bool> separatorPredicate, 
                                                         bool includeEmptyEntries = false,
                                                         bool includeSeparators = false)
    {
        int prevIndex = 0;
        int lastIndex = 0;
        var query = source.Select((t, index) => { lastIndex = index; return new { t, index }; })
                          .Where(a => separatorPredicate(a.t));
        foreach (var item in query)
        {
            if (item.index == prevIndex && !includeEmptyEntries)
            {
                prevIndex++;
                continue;
            }
            yield return source.Skip(prevIndex)
                               .Take(item.index - prevIndex + (!includeSeparators ? 0 : 1));
            prevIndex = item.index + 1;
        }
        if (prevIndex <= lastIndex)
            yield return source.Skip(prevIndex);
    }

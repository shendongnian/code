    public static IEnumerable<IList<T>> SplitBy<T>(this IEnumerable<T> source, 
                                                   Func<T, bool> startPredicate,
                                                   Func<T, bool> endPredicate, 
                                                   bool includeDelimiter)
    {
        var l = new List<T>();
        foreach (var s in source)
        {
            if (startPredicate(s))
            {
                if (l.Any())
                {
                    l = new List<T>();
                }
                l.Add(s);
            }
            else if (l.Any())
            {
                l.Add(s);
            }
            
            if (endPredicate(s))
            {
                if (includeDelimiter)
                    yield return l;
                else
                    yield return l.GetRange(1, l.Count - 2);
                l = new List<T>();
            }
        }
    }

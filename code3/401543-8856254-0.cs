    public static IOrderedEnumerable<Tuple<int,int>> GetDictionaryHistogram<U, V, W>(ConcurrentDictionary<U, IDictionary<V, W>> dictionary)
    {
        return dictionary.Select(p => p.Value.Count)
                         .GroupBy(p => p)
                         .Select(p => new Tuple<int, int>(p.Key, p.Count()))
                         .OrderBy(p => p.Item1);
    }

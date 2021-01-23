    static List<List<T>> Split<T>(IEnumerable<T> list, int sublistsize)
    {
        return list.Select((i, idx) => new { Item = i, Index = idx })
             .GroupBy(x => x.Index / sublistsize)
             .Select(g => g.Select(x => x.Item).ToList())
             .ToList();
    }

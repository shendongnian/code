    public static IEnumerable<int> GetIndices<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        return items.Select( (item, index) => new { Item = item, Index = index })
                         .Where(p => predicate(p.Item))
                         .Select(p => p.Index);
    }

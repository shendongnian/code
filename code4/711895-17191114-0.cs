    public static IEnumerable<T> GetIndices<T>(this IEnumerable<T> inputSequence, IEnumerable<int> indices)
    {
        var items = inputSequence.Select((Item, Index) => new { Item, Index })
           .Join(indices, x => x.Index, index => index, (x, index) => x.Item);
        foreach (T item in items)
            yield return item;
    }

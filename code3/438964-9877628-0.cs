    public static void AddRange<TCol, TItem>(this TCol collection, IEnumerable<TItem> range)
        where TCol : ICollection<TItem>
    {
        var list = collection as List<TItem>;
        if (list != null)
        {
            list.AddRange(range);
            return;
        }
        foreach (var item in range)
            collection.Add(item);
    }

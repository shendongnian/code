    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int batchSize)
    {
         return items.Select((item, inx) => new { item, inx })
                     .GroupBy(x => x.inx / batchSize)
                     .Select(g => g.Select(x => x.item));
    }

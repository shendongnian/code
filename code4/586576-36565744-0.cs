    public static class MyExtensions
        {
            public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int maxItems)
            {
                return items.Select((item, index) => new { item, index })
                            .GroupBy(x => x.index / maxItems)
                            .Select(g => g.Select(x => x.item));
            }
    
            public static IEnumerable<T> Batch2<T>(this IEnumerable<T> items, int skip, int take)
            {
                return items.Skip(skip).Take(take);
            }
    
        }

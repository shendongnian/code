    public static IQueryable<GroupedCount<TKey>> ToGroupedCounts<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, bool> pred, Func<TSource, TKey> keyGen, Func<TSource, int> tallyGen)
    {
        currentShift.FilingMeasurements
                    .Where(pred)
                    .GroupBy(keyGen, tallyGen)
                    .Select(t => new GroupedCount<TKey>{ Key = t.Key, Count = t.Sum() });
    }

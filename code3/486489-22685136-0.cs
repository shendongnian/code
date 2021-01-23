    public static ParallelQuery<TSource> AsDebugFriendlyParallel<TSource>(this IEnumerable<TSource> source)
    {
        var pQuery = source.AsParallel();
        #if DEBUG
        pQuery = pQuery.WithDegreeOfParallelism(1);
        #endif
        return pQuery;
    }

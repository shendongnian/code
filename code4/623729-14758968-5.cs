    public static IEnumerable<TResult> Bar<TSource, TResult>(
        IEnumerable<IQueryable<TSource>> queries,
        Func<IQueryable<TSource>, IQueryable<TResult>> selector)
    {
        return queries.Select(selector)
            .AsParallel()
            .Select(query => query.ToList())
            .SelectMany(results => results);
    }

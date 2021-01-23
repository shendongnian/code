    public static IEnumerable<T> Foo<T>(IEnumerable<IQueryable<T>> queries)
    {
        return queries.AsParallel()
                .Select(query => query.ToList())
                .SelectMany(results => results);
    }

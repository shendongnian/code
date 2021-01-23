    static readonly Func<DbContext, IQueryable<T>> compiledQuery = CompiledQuery.Compile<DbContext, IQueryable<T>>(/*your query goes here*/);
    using (DbContext context = new DbContext())
    {
        IQueryable<T> results = compiledQuery.Invoke(context);
    }

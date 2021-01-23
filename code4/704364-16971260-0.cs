    IQueryable<TResult> GetCombinedQuery<T, TResult> (DataContext dataContext, Func<DataContext, IQueryable<T>> dbQueryableProvider, Func<IQueryable<T>, IQueryable<TResult>> queryProvider)
    {
      var dbDataSource = dbQueryableProvider (dataContext);
      var dbQuery = queryProvider (dbDataSource);
      var inMemorySource = dataContext.GetObjectStateEntries (EntityState.Added).Select (e => e.Entity).OfType<T>();
      var inMemoryQuery = queryProvider (inMemorySource);
      return dbQuery.Concat (inMemoryQuery);
    }

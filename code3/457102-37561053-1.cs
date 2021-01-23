    public string GetSqlColumnNameFor<TSource>(this DbSet<T> source, Expression<Func<TSource, TResult>> selector)
    {
        var sql = source.Select(selector).ToString();
        var columnName = sql... // TODO : Some regex parsing
        return 
           columnName;
    }

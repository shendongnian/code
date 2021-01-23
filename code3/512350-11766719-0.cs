    public static IQueryable<T> WhereLike<T>(
        this IQueryable<T> source,
        string propertyName,
        string pattern)
    {
        if (null == source)
            throw new ArgumentNullException("source");
        if (string.IsNullOrEmpty(propertyName))
            throw new ArgumentNullException("propertyName");
    
        var a = Expression.Parameter(typeof(T), "a");
        // Wrap the property access in a call to Convert.ToString
        var prop = Expression.Property(a, propertyName);
        var conv = Expression.Call(typeof(Convert), "ToString", null, prop);
        // Basically: SqlMethods.Like(Convert.ToString([prop]), pattern)
        var body = Expression.Call(
            typeof(SqlMethods), "Like", null,
            conv,
            Expression.Constant(pattern));
        var fn = Expression.Lambda<Func<T, bool>>(body, a);
    
        return source.Where(fn);
    }

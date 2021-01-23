    public static IEnumerable<T> MyMethod<T>(
        this IQueryable<T> entity, 
        string pattern, 
        params Expression<Func<T, string>>[] selectors)
    {
        var method = typeof(SqlFunctions).GetMethod("PatIndex");
        foreach(var selector in selectors)
        {
            var param = Expression.Parameter(typeof(T));
            var call = Expression.Call(method, Expression.Constant(pattern), selector);
            var gt = Expression.GreaterThan(call, Expression.Constant(0));
            var filter = Expression.Lamda(call, param);
            entity = entity.Where(filter);
        }
        return entity;
    }

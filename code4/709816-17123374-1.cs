    public static IQueryable<T> WildcardSearch<T>(this IQueryable<T> entity,
        string param, Expression<Func<T, string>> selector)
    {
        var lambda = Expression.Lambda<Func<T, bool>>(
            Expression.GreaterThan(
                Expression.Call(
                    typeof(SqlFunctions), "PatIndex", null,
                    Expression.Constant(param, typeof(string)),
                    selector.Body),
                Expression.Constant(0)),
            selector.Parameters);
        return entity.Where(lambda);
    }

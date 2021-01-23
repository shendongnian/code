    public static IOrderedQueryable<T> EuclideanDistanceOrder<T>(this IQueryable<T> query, IEnumerable<Expression<Func<T, double>>> expressions)
    {
        var parameter = Expression.Parameter(typeof(T), "item");
        var seed = Expression.Lambda<Func<T, double>>(Expression.Constant((double)0), parameter);
        return query.OrderBy(expressions.Aggregate(seed, GetAggregateExpression));
    }
    private static Expression<Func<T, double>> GetAggregateExpression<T>(Expression<Func<T, double>> sum, Expression<Func<T, double>> item)
    {
        var parameter = Expression.Parameter(typeof(T), "item");
        return Expression.Lambda<Func<T, double>>(Expression.Add(Expression.Invoke(sum, parameter), Expression.Power(Expression.Invoke(item, parameter), Expression.Constant((double)2))), parameter);
    }

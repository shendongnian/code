    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> enumerable, string sortColumn)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var mySortExpression = Expression.Lambda<Func<T, object>>(Expression.Property(param, sortColumn), param);
        return enumerable.OrderByDescending(mySortExpression);;
     }

    /// <summary>
    /// Returns a queryable sequence of TResult elements which is composed through specified property evaluation.
    /// </summary>
    public static IQueryable<TResult> WithInfo<TItem, TProperty, TResult>(this IQueryable<TItem> q, Expression<Func<TItem, TProperty>> propertySelector, Expression<Func<TItem, TProperty, TResult>> resultSelector)
    {
        ParameterExpression param = Expression.Parameter(typeof(TItem));
        InvocationExpression prop = Expression.Invoke(propertySelector, param);
        var lambda = Expression.Lambda<Func<TItem, TResult>>(Expression.Invoke(resultSelector, param, prop), param);
        return q.Select(lambda);
    }

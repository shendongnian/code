    public static IQueryable<TEntity> WhereIn<TEntity, TValue>
    (
        this ObjectQuery<TEntity> query,
        Expression<Func<TEntity, TValue>> selector,
        IEnumerable<TValue> collection
    )
    {
        ParameterExpression p = selector.Parameters.Single();
 
        //if there are no elements to the WHERE clause,
        //we want no matches:
        if (!collection.Any()) return query.Where(x=>false);
 
        if (collection.Count() > 3000) //could move this value to config
            throw new ArgumentException("Collection too large - execution will cause stack overflow", "collection");
 
        IEnumerable<Expression> equals = collection.Select(value =>
           (Expression)Expression.Equal(selector.Body,
                Expression.Constant(value, typeof(TValue))));
 
        Expression body = equals.Aggregate((accumulate, equal) =>
            Expression.Or(accumulate, equal));
 
        return query.Where(Expression.Lambda<Func<TEntity, bool>>(body, p));
    }

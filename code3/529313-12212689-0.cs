    string methodName = "OrderBy";
    if (direction == SortDirection.Descending) {
        methodName += "Descending";
    }
    var paramExp = Expression.Parameter(typeof(T), String.Empty);
    var propExp = Expression.PropertyOrField(paramExp, sortExpression);
    // p => p.sortExpression
    var sortLambda = Expression.Lambda(propExp, paramExp);
    var methodCallExp = Expression.Call(
                                typeof(Queryable),
                                methodName,
                                new[] { typeof(T), propExp.Type },
                                source.Expression,
                                Expression.Quote(sortLambda)
                            );
    return (IQueryable<T>)source.Provider.CreateQuery(methodCallExp);
}

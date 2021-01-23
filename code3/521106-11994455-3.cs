    private IQueryable<T> OrderQuery<T>(IQueryable<T> query, OrderParameter orderBy)
    {
        string orderMethodName = orderBy.Direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending";
        Type t = typeof(T);
        var param = Expression.Parameter(t, "user");
        var property = t.GetProperty(orderBy.Attribute);
        return query.Provider.CreateQuery<T>(
            Expression.Call(
                typeof(Queryable),
                orderMethodName,
                new Type[] { t, typeof(string) },
                query.Expression,
                Expression.Quote(
                    Expression.Lambda(
                        Expression.Property(param, property),
                        param))
            ));
    }

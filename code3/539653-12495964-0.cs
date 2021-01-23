    private IQueryable<T> OrderQuery<T>(IQueryable<T> query, OrderParameter orderBy)
    {
        string orderMethodName = orderBy.Direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending";
        Type t = typeof(T);
        var param = Expression.Parameter(t, "shipment");
        var property = t.GetProperty(orderBy.Attribute);
        /* We can't just call OrderBy[Descending] with an Expression
         * parameter because the second type argument to OrderBy is not
         * known at compile-time.
         */
        return query.Provider.CreateQuery<T>(
            Expression.Call(
                typeof(Queryable),
                orderMethodName,
                new Type[] { t, property.PropertyType },
                query.Expression,
                Expression.Quote(
                    Expression.Lambda(
                        Expression.Property(param, property),
                        param))
            ));
    }

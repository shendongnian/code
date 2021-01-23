    private IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string attribute, SortDirection direction)
    {
        try
        {
            string orderMethodName = direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            Type t = typeof(T);
            var param = Expression.Parameter(t);
            var property = t.GetProperty(attribute);
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
        catch (Exception) // Probably invalid input, you can catch specifics if you want
        {
            return query; // Return unsorted query
        }
    }

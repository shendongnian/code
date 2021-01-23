    public IQueryable<T> OrderBy<T>(this IQueryable<T> query, string attribute, SortDirection direction)
    {
        return ApplyOrdering(query, attribute, direction, "OrderBy");
    }
    public IQueryable<T> ThenBy<T>(this IQueryable<T> query, string attribute, SortDirection direction)
    {
        return ApplyOrdering(query, attribute, direction, "ThenBy");
    }
    private IQueryable<T> ApplyOrdering<T>(IQueryable<T> query, string attribute, SortDirection direction, string orderMethodName)
    {
        try
        {
            if (direction == SortDirection.Descending) orderMethodName += "Descending";
            
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

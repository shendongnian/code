    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string sortColumn, bool descending) 
    {
        // Dynamically creates a call like this: query.OrderBy(p => p.SortColumn)
        var parameter = Expression.Parameter(typeof(T), "p");
    
        string command = "OrderBy";
    
        if (descending)
        {
            command = "OrderByDescending";
        }
    
        Expression resultExpression = null;    
        
        var property = typeof(T).GetProperty(sortColumn);
        // this is the part p.SortColumn
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        // this is the part p => p.SortColumn
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        // finally, call the "OrderBy" / "OrderByDescending" method with the order by lamba expression
        resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(T), property.PropertyType },
           query.Expression, Expression.Quote(orderByExpression));
       
        return query.Provider.CreateQuery<T>(resultExpression);
    }

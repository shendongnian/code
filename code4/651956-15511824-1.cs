    public static IEnumerable<T> OrderBy<T>(
           this IEnumerable<T> collection, 
           string columnName
           //, SortDirection direction
    )
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "x");   // x
        Expression property = Expression.Property(param, columnName);       // x.ColumnName
        Func<T, object> lambda = Expression.Lambda<Func<T, object>>(        // x => x.ColumnName
                Expression.Convert(property, typeof(object)),
                param)
            .Compile();
        Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> expression = (c, f) => c.OrderBy(f); // here you can use OrderByDescending basing on SortDirection
    
        IEnumerable<T> sorted = expression(collection, lambda);
        return sorted;
    }

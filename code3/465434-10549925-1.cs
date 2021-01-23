    public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> collection, 
           string columnName, SortDirection direction)
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "x"); // x
        Expression property = Expression.Property(param, columnName);     // x.ColumnName
        Func<T, object> func = Expression.Lambda<Func<T, object>>(        // x => x.ColumnName
            Expression.Convert(Expression.Property(param, columnName), 
            typeof(object)), param).Compile();
    
        Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> expression =
            SortExpressionBuilder<T>.CreateExpression(direction);
        IEnumerable<T> sorted = expression(collection, func);
        return sorted;
    }

    public static class SortExpressionBuilder<T>
    {
        private static IDictionary<SortDirection, ISortExpression> directions =  new Dictionary<SortDirection, ISortExpression>
        {
            { SortDirection.Ascending, new OrderByAscendingSortExpression() },
            { SortDirection.Descending, new OrderByDescendingSortExpression() }
        };
    
        interface ISortExpression
        {
            Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> GetExpression();
        }
    
        class OrderByAscendingSortExpression : ISortExpression
        {
            public Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> GetExpression()
            {
                return (c, f) => c.OrderBy(f);
            }
        }
    
        class OrderByDescendingSortExpression : ISortExpression
        {
            public Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> GetExpression()
            {
                return (c, f) => c.OrderByDescending(f);
            }
        }
    
        public static Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> CreateExpression(SortDirection direction)
        {
            return directions[direction].GetExpression();
        }
    }
    
    public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> collection, string columnName, SortDirection direction)
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "x"); // x
        Expression property = Expression.Property(param, columnName);     // x.ColumnName
        Func<T, object> func = Expression.Lambda<Func<T, object>>(        // x => x.ColumnName
           Expression.Convert(Expression.Property(param, columnName), 
           typeof(object)), param
        ).Compile();
    
        Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> expression = SortExpressionBuilder<T>.CreateExpression(direction);
        IEnumerable<T> sorted = expression(collection, func);
        return sorted;
    }

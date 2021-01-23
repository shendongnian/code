    public static class FilterStatic
    {
        // passing expression, accessing value
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Expression<Func<T, bool>> predicate)
        {
            var binExpr = predicate.Body as BinaryExpression;
            var value = binExpr.Right;
    
            var func = predicate.Compile();
            return collection.Where(func);
        }
        
        // passing Func
        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate);
        }
    }

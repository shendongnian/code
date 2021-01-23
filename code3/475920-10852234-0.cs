    public static class IQueryableExtensions
    {
        public static IQueryable<T> IsCurrent<T>(this IQueryable<T> query,
            Expression<Func<T, DateTime?>> expressionEnd,
            Expression<Func<T, DateTime?>> expressionStart,
            DateTime asOf) where T : class
        {
            // Lambdas being sent in
            ParameterExpression paramEnd = expressionEnd.Parameters.Single();
            ParameterExpression paramStart = expressionStart.Parameters.Single();
            
            // GT Comparison
            BinaryExpression expressionGT = ExpressionGT(expressionEnd.Body, asOf);
                
            // LT Comparison
            BinaryExpression expressionLT = ExpressionLE(expressionStart.Body, asOf);
            query = query.Where(Expression.Lambda<Func<T, bool>>(expressionGT, paramEnd))
                         .Where(Expression.Lambda<Func<T, bool>>(expressionLT, paramStart));
            return query;
        }
        private static BinaryExpression ExpressionLE(Expression body, DateTime value)
        {
            return Expression.LessThanOrEqual(body, Expression.Constant(value, typeof(DateTime)));
        }
        private static BinaryExpression ExpressionGT(Expression body, DateTime value)
        {
            return Expression.GreaterThan(body, Expression.Constant(value, typeof(DateTime)));
        }
    }

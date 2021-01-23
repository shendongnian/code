    public static class QueryableExtensions
    {
        public static IQueryable<T> Search<T>(this IQueryable<T> source, Expression<Func<T, string>> stringProperty, params string[] searchTerms)
        {
            if (!searchTerms.Any())
            {
                return source;
            }
            Expression orExpression = null;
            foreach (var searchTerm in searchTerms)
            {
                //Create expression to represent x.[property].Contains(searchTerm)
                var searchTermExpression = Expression.Constant(searchTerm);
                var containsExpression = BuildContainsExpression(stringProperty, searchTermExpression);
                orExpression = BuildOrExpression(orExpression, containsExpression);
            }
            var completeExpression = Expression.Lambda<Func<T, bool>>(orExpression, stringProperty.Parameters);
            return source.Where(completeExpression);
        }
        private static Expression BuildOrExpression(Expression existingExpression, Expression expressionToAdd)
        {
            if (existingExpression == null)
            {
                return expressionToAdd;
            }
            //Build 'OR' expression for each property
            return Expression.OrElse(existingExpression, expressionToAdd);
        }
        private static MethodCallExpression BuildContainsExpression<T>(Expression<Func<T, string>> stringProperty, ConstantExpression searchTermExpression)
        {
            return Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);
        }
    }

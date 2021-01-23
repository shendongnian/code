    public static class Extension
    {
        public static IOrderedQueryable<T> EuclideanDistanceOrder<T>(
            this IQueryable<T> query, 
            IEnumerable<Expression<Func<T, double>>> pExpressions, 
            IEnumerable<Expression<Func<T, double>>> qExpressions)
        {
            var parameter = Expression.Parameter(typeof(T));
            var pBodies = pExpressions
                .Select(x => ReplaceParameter(x.Body, parameter))
                .ToArray();
            var qBodies = qExpressions
                .Select(x => ReplaceParameter(x.Body, parameter))
                .ToArray();
            var distances = pBodies
                .Select((x, i) => CreateDistance(x, qBodies[i]))
                .ToArray();
            var squers = distances
                .Select(x => CreateSquerExpression(x))
                .ToArray();
            var sum = squers.First();
            for (int i = 1; i < squers.Count(); i++)
            {
                sum = Expression.Add(sum, squers[i]);
            }
            var funcExpression = Expression.Lambda<Func<T, double>>(sum, parameter);
            //the sqrt is irrelevant to order of this sequence
            return query.OrderBy(funcExpression);
        }
        private static Expression CreateDistance(Expression p, Expression q)
        {
            return Expression.Subtract(q, p);
        }
        private static Expression CreateSquerExpression(Expression x)
        {
            var method = typeof(Math).GetMethod("Pow", BindingFlags.Static | BindingFlags.Public);
            return Expression.Call(method, x, Expression.Constant(2.0));
        }
        private static Expression ReplaceParameter(Expression expression, ParameterExpression parameter)
        {
            var unaryExpression = expression as UnaryExpression;
            MemberExpression memberExpression;
            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = expression as MemberExpression;
            }
            if (memberExpression == null)
                throw new NotImplementedException();
            if (!(memberExpression.Expression is ParameterExpression) || !(memberExpression.Member is PropertyInfo))
                throw new NotImplementedException();
            return Expression.Property(parameter, (PropertyInfo)memberExpression.Member);
        }
    }

    public static class CollectionHelper
    {
        public static IQueryable Filter<T>(this IQueryable source, string[] properties, string[] values)
        {
            var lambda = CombineLambdas<T>(properties, values);
            var result = typeof (Queryable).GetMethods().First(
                method => method.Name == "Where"
                          && method.IsGenericMethodDefinition)
                                           .MakeGenericMethod(typeof (T))
                                           .Invoke(null, new object[] {source, lambda});
            return (IQueryable<T>) result;
        }
        // combine lambda expressions using OR operator
        private static LambdaExpression CombineLambdas<T>(string[] properties, string[] values)
        {
            var param = Expression.Parameter(typeof (T));
            LambdaExpression prev = null;
            foreach (var value in values)
            {
                foreach (var property in properties)
                {
                    LambdaExpression current = GetContainsExpression<T>(property, value);
                    if (prev != null)
                    {
                        Expression body = Expression.Or(Expression.Invoke(prev, param),
                                                        Expression.Invoke(current, param));
                        prev = Expression.Lambda(body, param);
                    }
                    prev = prev ?? current;
                }
            }
            return prev;
        }
        // construct expression tree to represent String.Contains
        private static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof (T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            var method = typeof (string).GetMethod("Contains", new[] {typeof (string)});
            var someValue = Expression.Constant(propertyValue, typeof (string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);
            return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
        }
    }

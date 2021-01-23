    public static IOrderedQueryable ApplyFilter<T>(IQueryable source, string[] properties, string[] values)
            {
                LambdaExpression lambda = CombineLambdas<T>(properties, values);
                object result = typeof(Queryable).GetMethods().First(
                        method => method.Name == "Where"
                                && method.IsGenericMethodDefinition
                                && method.GetGenericArguments().Length == 1
                                && method.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T))
                        .Invoke(null, new object[] { source, lambda });
                return (IOrderedQueryable<T>)result;
            }
    
            private static LambdaExpression CombineLambdas<T>(string[] properties, string[] values)
            {
                ParameterExpression p = Expression.Parameter(typeof(T));
                LambdaExpression prev = null;
                foreach (var value in values)
                {
                    foreach (var property in properties)
                    {
                        LambdaExpression current = GetContainsExpression<T>(property, value);
                        if (prev == null)
                        {
                            prev = current;
                        }
                        else
                        {
                            Expression body = Expression.Or(Expression.Invoke(prev, p), Expression.Invoke(current, p));
                            prev = Expression.Lambda(body, p);
                        }
                    }
                }
                return prev;
            }
    
            private static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string propertyValue)
            {
                var parameterExp = Expression.Parameter(typeof(T), "type");
                var propertyExp = Expression.Property(parameterExp, propertyName);
                var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var someValue = Expression.Constant(propertyValue, typeof(string));
                var containsMethodExp = Expression.Call(propertyExp, method, someValue);
    
                return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
            }

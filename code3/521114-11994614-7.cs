        public static IQueryable<T> WhereStringContains<T>(this IQueryable<T> query, string propertyName, string contains)
        {
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(contains, typeof(string));
            var containsExpression = Expression.Call(propertyExpression, method, someValue);
            return query.Where(Expression.Lambda<Func<T, bool>>(containsExpression, parameter));
        }
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(propertyExpression, new[] { parameter });
            return typeof(Queryable).GetMethods()
                                    .Where(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                                    .Single()
                                    .MakeGenericMethod(new[] { typeof(T), propertyType })
                                    .Invoke(null, new object[] { query, lambda }) as IOrderedQueryable<T>;
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(propertyExpression, new[] { parameter });
            return typeof(Queryable).GetMethods()
                                    .Where(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2)
                                    .Single()
                                    .MakeGenericMethod(new[] { typeof(T), propertyType })
                                    .Invoke(null, new object[] { query, lambda }) as IOrderedQueryable<T>;
        }

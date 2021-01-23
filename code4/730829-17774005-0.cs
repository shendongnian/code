    public static IQueryable<TSource> OfTypes<TSource>(
            this IQueryable<TSource> source,
            params Type[] types)
        {
            if (!types.Any())
            {
                return source;
            }
            var param = Expression.Parameter(typeof(TSource), "p");
            Expression finalExpression = Expression.TypeIs(param, types.First());
            foreach (var type in types.Skip(1))
            {
                finalExpression = Expression.OrElse(
                    Expression.TypeIs(param, type),
                    finalExpression);
            }
            var lambdaExpression = Expression.Lambda<Func<TSource, bool>>(
                finalExpression, param);
            return source.Where(lambdaExpression);
        }

        public static IQueryable<T> AddSearchParameter<T>(this IQueryable<T> query, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            if (condition)
            {
                query = query.Where(predicate);
            }
            return query;
        }

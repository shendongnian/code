        private static IQueryable<T> GetOrderQuery<T>(this IQueryable<T> q, BaseFilterCollection filter)
        {
            q = q.OrderBy(GetExpression<T>(filter.SortField));
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, filter.SortField);
            var exp = Expression.Lambda(prop, param);
            string method = filter.SortDirection == SortDirectionType.Asc ? "ThenBy" : "ThenByDescending";
            Type[] types = { q.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(rs);
        }
        private static Expression<Func<T, bool>> GetExpression<T>(string sortField)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "p");
            Expression prop = Expression.Property(param, sortField);
            Expression exp = Expression.Equal(prop, Expression.Constant(null));
            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

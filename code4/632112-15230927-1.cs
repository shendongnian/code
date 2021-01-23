        public static IQueryable<T> OrderBy<T>(this IQueryable<T> items, string propertyName, SortDirection direction)
        {
            var typeOfT = typeof(T);
            var parameter = Expression.Parameter(typeOfT, "parameter");
            var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
            var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
            var orderExpression = Expression.Lambda(propertyAccess, parameter);
            string orderbyMethod = (direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending");
            var expression = Expression.Call(typeof(Queryable), orderbyMethod, new[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
            return items.Provider.CreateQuery<T>(expression);
        }

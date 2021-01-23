        public static IQueryable<T> OrderByFieldNullsLast<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            //We are rebuilding .OrderByDescending(p => p.SortField.HasValue).ThenBy(p => p.SortField)
            //i.e. sort first by whether sortfield has a value, then by sortfield asc or sortfield desc
            //create the expression tree that represents the generic parameter to the predicate
            var param = Expression.Parameter(typeof(T), "p");
            //create an expression tree that represents the expression p=>p.SortField.HasValue 
            var prop = Expression.Property(param, SortField);
            var hasValue = Expression.Property(prop, "HasValue");
            var exp = Expression.Lambda(hasValue, param);
            
            string method = "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var orderByCallExpression = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            //now do the ThenBy bit,sending in the above expression to the Expression.Call
            exp = Expression.Lambda(prop, param);
            types = new Type[] { q.ElementType, exp.Body.Type };
            method = Ascending ? "ThenBy" : "ThenByDescending";
            var ThenByCallExpression = Expression.Call(typeof(Queryable), method, types,orderByCallExpression, exp);
            
            return q.Provider.CreateQuery<T>(ThenByCallExpression);
        }

    public static class QueryableExtensions  
    {  
        public static IQueryable<T> Search<T>(this IQueryable<T> source, Expression<Func<T, string>> stringProperty, string searchTerm)  
        {  
            if (String.IsNullOrEmpty(searchTerm))  
            {  
                return source;  
            }  
      
            // The below represents the following lamda:  
            // source.Where(x => x.[property] != null  
            //                && x.[property].Contains(searchTerm))  
      
            //Create expression to represent x.[property] != null  
            var isNotNullExpression = Expression.NotEqual(stringProperty.Body, Expression.Constant(null));  
      
            //Create expression to represent x.[property].Contains(searchTerm)  
            var searchTermExpression = Expression.Constant(searchTerm);  
            var checkContainsExpression = Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);  
      
            //Join not null and contains expressions  
            var notNullAndContainsExpression = Expression.AndAlso(isNotNullExpression, checkContainsExpression);  
      
            var methodCallExpression = Expression.Call(typeof(Queryable),  
                                                       "Where",  
                                                       new Type[] { source.ElementType },  
                                                       source.Expression,  
                                                       Expression.Lambda<Func<T, bool>>(notNullAndContainsExpression, stringProperty.Parameters));  
      
            return source.Provider.CreateQuery<T>(methodCallExpression);  
        }  
    }  

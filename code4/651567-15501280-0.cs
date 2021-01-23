    /// <summary>  
    /// Performs a search on the supplied string property  
    /// </summary>  
    /// <param name="stringProperty">Property to search upon</param>  
    /// <param name="searchTerm">Search term</param>  
    public virtual IQueryable<T> Search(Expression<Func<T, string>> stringProperty, string searchTerm)  
    {  
        var source = this.RetrieveAll();  
      
        if (String.IsNullOrEmpty(searchTerm))  
        {  
            return source;  
        }  
      
        //The following is the query we are trying to reproduce  
        //source.Where(x => T.[property] != null   
        //               && T.[property].Contains(searchTerm)  
      
        //Create expression to represent T.[property] != null  
        var isNotNullExpression = Expression.NotEqual(stringProperty.Body, Expression.Constant(null));  
      
        //Create expression to represent T.[property].Contains(searchTerm)  
        var searchTermExpression = Expression.Constant(searchTerm);  
        var checkContainsExpression = Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);  
      
        //Join not null and contains expressions  
        var notNullAndContainsExpression = Expression.AndAlso(isNotNullExpression, checkContainsExpression);  
      
        //Build final expression  
        var methodCallExpression = Expression.Call(typeof (Queryable),   
                                                   "Where",   
                                                   new Type[] {source.ElementType},   
                                                   source.Expression,   
                                                   Expression.Lambda<Func<Club, bool>>(notNullAndContainsExpression, stringProperty.Parameters));  
      
        return source.Provider.CreateQuery<T>(methodCallExpression);  
    }  

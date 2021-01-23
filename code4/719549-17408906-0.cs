    public static IQueryable<T> Search<T>(this IQueryable<T> source, string searchTerm, params Expression<Func<T, string>>[] stringProperties)  
    {  
        if (String.IsNullOrEmpty(searchTerm))  
        {  
            return source;  
        }  
      
        var searchTermExpression = Expression.Constant(searchTerm);  
      
        //Variable to hold merged 'OR' expression  
        Expression orExpression = null;  
        //Retrieve first parameter to use accross all expressions  
        var singleParameter = stringProperties[0].Parameters.Single();  
      
        //Build a contains expression for each property  
        foreach (var stringProperty in stringProperties)  
        {  
            //Syncronise single parameter accross each property  
            var swappedParamExpression = SwapExpressionVisitor.Swap(stringProperty, stringProperty.Parameters.Single(), singleParameter);  
      
            //Build expression to represent x.[propertyX].Contains(searchTerm)  
            var containsExpression = BuildContainsExpression(swappedParamExpression, searchTermExpression);  
      
            orExpression = BuildOrExpression(orExpression, containsExpression);  
        }  
      
        var completeExpression = Expression.Lambda<Func<T, bool>>(orExpression, singleParameter);  
        return source.Where(completeExpression);  
    }  
      
    private static Expression BuildOrExpression(Expression existingExpression, Expression expressionToAdd)  
    {  
        if (existingExpression == null)  
        {  
            return expressionToAdd;  
        }  
      
        //Build 'OR' expression for each property  
        return Expression.OrElse(existingExpression, expressionToAdd);  
    }  
      
    private static MethodCallExpression BuildContainsExpression<T>(Expression<Func<T, string>> stringProperty, ConstantExpression searchTermExpression)  
    {  
        return Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);  
    }  

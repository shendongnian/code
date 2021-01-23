    public Expression<Func<County, Boolean>> GetPredicate(List<String> terms)
    {
    //The string method - Contains
    MethodInfo mContains = typeof(String).GetMethod("Contains");
    
    //The parameter - county
    ParameterExpression pe = Expression.Parameter(typeof(County), "County");
    
    //The property - Name
    Expression property = Expression.Property(pe, "Name");
    
    //expression body
    Expression body = null;
    
    foreach(String term in terms)
    {
      //the constant to look for
      Expression searchTerm = Expression.Constant(term);
      
       //build expression body
       if(body == null) body = Expression.Call(property, mContains, searchTerm);
       else body = Expression.OrElse(body, 
           Expression.Call(property, mContains, searchTerm));
    }
    
    //create predicate
    return Expression.Lambda<Func<County, Boolean>>(body, pe);
    }

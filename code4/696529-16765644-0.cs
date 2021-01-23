    //user => user.SomeProperty == someValue
    
    //the parameter of the predicate, a User object in your case 
    ParameterExpression parameter = Expression.Parameter(typeof(User), "user");
    
    //the property of the user object to use in expression
    Expression property = Expression.Property(parameter, myPropertyNameString);
    
    //the value to compare to the user property
    Expression val = Expression.Constant(myValueToCompare);
    
    //the binary expression using the above expressions
    BinaryExpression expEquals = Expression.Equal(property, val);
    
    //create the Expression<Func<T, Boolean>>
    var predicate = Expression.Lambda<Func<User, Boolean>>(expEquals, parameter);

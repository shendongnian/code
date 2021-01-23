    ParameterExpression p = Expression.Parameter(typeof(Person));
    Expression personType = Expression.MakeMemberAccess(p, typeof(Person).GetProperty("PersonType"));
    Expression personTypeExpression = Expression.Constant(false);
    if (IncludeLazyPeople)
    	personTypeExpression = Expression.OrElse(personTypeExpression, Expression.Equal(personType, Expression.Constant((int)PersonTypes.Lazy));
    
    //... same as above only with different Constant values
    
    // filter the people for all included types
    var filteredPeople = ctx.People.Where(Expression.Lambda<Func<Person,bool>>(personTypeExpression,p));

    List<Expression<Func<Person, object>>> list =
      new List<Expression<Func<Person, object>>>();
    ParameterExpression param = Expression.Parameter(typeof(Person), "p");
    
    // maps to expression p => p.FirstName
    Expression member = getExpressionPart(param, "Firstname", null);
    list.Add(Expression.Lambda<Func<Person, object>>(member, param));
    
    // maps to expression p => p.Department.NameOfDepartment
    member = getExpressionPart(param, "Department", "NameOfDepartment");
    list.Add(Expression.Lambda<Func<Person, object>>(member, param));
    

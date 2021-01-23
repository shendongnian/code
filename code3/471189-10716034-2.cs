    ParameterExpression parameter = Expression.Parameter(typeof (GoalsModelUnitOfWork), "i");
    MemberExpression property = Expression.Property(parameter, "AcademicCycles");
    
    var queryableType = typeof (IQueryable<>).MakeGenericType(typeof (AcademicCycle));
    var delegateType = typeof (Func<,>).MakeGenericType(typeof (GoalsModelUnitOfWork), queryableType);
    
    var yourExpression = Expression.Lambda(delegateType, property, parameter);

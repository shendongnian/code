    Expression parameter = Expression.Parameter(type, "p");
    Expression target = parameter;
    foreach (string property in propertyParts)
    {
        target = Expression.Property(target, property);
    }
    var orderByExp = Expression.Lambda(target, parameter);

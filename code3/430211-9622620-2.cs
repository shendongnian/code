    var entityType = propertyInfo.DeclaringType;
    var parameter = Expression.Parameter(entityType, "entity");
    var property = Expression.Property(parameter, propertyInfo);
    var funcType = typeof(Func<,>).MakeGenericType(entityType, propertyInfo.PropertyType);
    var lambda = Expression.Lambda(funcType, property, parameter);
    structureConfiguration.GetType()
       .GetMethod("Ignore")
       .MakeGenericMethod(propertyInfo.PropertyType)
       .Invoke(structureConfiguration, new[]{lambda});

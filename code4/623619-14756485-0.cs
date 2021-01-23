    Type propType = prop.PropertyType;
    if (propType.IsGenericType)
    {
        Type enumerableType = propType.GetInterfaces().FirstOrDefault(it => it.IsGenericType && it.GetGenericTypeDefinition() == typeof(IEnumerable<>)));
        if(enumerableType != null)
        {
            Type elementType = enumerableType.GetGenericArguments()[0];
        }
    }

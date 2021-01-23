    var propertyType = propertyInfo.PropertyType;
    
    if (propertyType.IsGenericType &&
            propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
          propertyType = propertyType.GetGenericArguments()[0];
        }
    
    model.ModelProperties.Add(new KeyValuePair<Type, string>
                            (propertyType.Name,propertyInfo.Name));

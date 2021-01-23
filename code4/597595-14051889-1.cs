    object originalValue = reader[ordinal];
    Func<object, object> converter;
    if (!Mappings.TryGetValue(Tuple.Create(originalValue.GetType(), 
                                           propertyInfo.PropertyType),
                              out converter)
    {
        // Fall back to Convert.ChangeType
        converter = x => Convert.ChangeType(x, propertyInfo.PropertyType);
    }
    object targetValue = converter(originalValue);
    propertyInfo.SetValue(item, targetValue, null);

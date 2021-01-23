    public static T[] GetAllPropertyValuesForTypeinTree<T>(object rootObject)
    {
        var propertyInfos = rootObject.GetType().GetProperties();
        var withCorrectPropertyType = propertyInfos
            .Where(p => p.PropertyType == typeof(T)).ToList();
                
        var withListsOfType = propertyInfos.Where(p => 
            IsEnumerableOf<T>(p.PropertyType)).ToList();
        var complexProperties = propertyInfos.Except(
             withCorrectPropertyType.Concat(withListsOfType))
             .Where(p => !p.PropertyType.IsPrimitive && !p.PropertyType.IsGenericType);
    
        var complexValues = new List<T>();
        foreach (var complexProperty in complexProperties)
        {
             complexValues.AddRange(GetAllPropertyValuesForTypeinTree<T>(
                 complexProperty.GetValue(rootObject, null)));
        }
    
        var listValues = withListsOfType.Select(p => 
            (IEnumerable)p.GetValue(rootObject, null))
            .SelectMany(p => p.OfType<T>());
        var propertyValues = withCorrectPropertyType.Select(p => 
            (T) p.GetValue(rootObject, null));
        return propertyValues.Concat(listValues).Concat(complexValues).ToArray();
    }
    
    private static bool IsEnumerableOf<T>(Type type)
    {
        if (!typeof (IEnumerable).IsAssignableFrom(type)) 
            return false;
    
        return type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType
            && (interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>) 
            && type.GetGenericArguments()[0] == typeof(T)))
            || type == typeof(IEnumerable<T>);
     }

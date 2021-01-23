    var defaultTypeFor = new Dictionary<Type, Type>();
    defaultTypeFor[typeof(IList<>)] = typeof(List<>);
    ...
    var type = property.PropertyType;
    if (type.IsInterface) {
        // TODO: Throw an exception if the type doesn't exist in the dictionary
        if (type.IsGenericType) {
            type = defaultTypeFor[property.PropertyType.GetGenericTypeDefinition()];
            type = type.MakeGenericType(property.PropertyType.GetGenericArguments());
        }
        else {
            type = defaultTypeFor[property.PropertyType];
        }
    }
    theList = Activator.CreateInstance(type);

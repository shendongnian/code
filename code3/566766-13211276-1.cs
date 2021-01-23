    var defaultTypeFor = new Dictionary<Type, Type>();
    defaultTypeFor[typeof(IList<string>)] = typeof(List<string>);
    ...
    var type = property.PropertyType;
    if (type.IsInterface) {
        type = defaultTypeFor[property.PropertyType]; // TODO: Handle missing type
        if (type.IsGenericType)
            type = type.MakeGenericType(property.PropertyType.GetGenericArguments());
    }
    theList = Activator.CreateInstance(type);

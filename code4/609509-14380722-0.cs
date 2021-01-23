    Func<Type, bool> isGenericIDict =
      t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>);
    var type = propDescriptor.PropertyType;
    if (isGenericIDict(type) || type.GetInterfaces().Any(isGenericIDict))
    { // ..

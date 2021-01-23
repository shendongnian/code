    var genericCollectionType = typeof(IEnumerable<>);
    var isCollection = pi
      .PropertyType
      .GetInterfaces()
      .Where(type => type.IsGenericType)
      .Select(type => type.GetGenericTypeDefinition())
      .Contains(genericCollectionType);
    if (isCollection) {
      ...
    }

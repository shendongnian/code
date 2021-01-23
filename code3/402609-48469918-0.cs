    var fontTypeParam = typeof(MyFont).GetInterfaces()
        .Where(i => i.IsGenericType)
        .Where(i => i.GetGenericTypeDefinition() == typeof(IResourceDataType<>))
        .Select(i => i.GetGenericArguments().First())
        .First()
        ;

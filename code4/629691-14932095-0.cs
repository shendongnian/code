    var types = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(t => t.Name.StartsWith("Class"));
    foreach (var type in types)
    {
        var interfaceType = type.GetInterfaces()
                                .Single();
        kernel.Bind(type).To(interfaceType);
    }

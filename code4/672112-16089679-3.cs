    var registrations =
        from type in
            typeof(IRepository<>).Assembly.GetExportedTypes()
        where !service.IsAbstract
        where !service.IsGenericTypeDefinition
        from @interface in type.GetInterfaces()
        where @interface.IsGenericType
        where @interface.GetGenericTypeDefinition() ==
            typeof(IRepository<>)
        select new { Service = @interface, Impl = type };

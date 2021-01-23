    var repositoryTypes =
        OpenGenericBatchRegistrationExtensions.GetTypesToRegister(
            container, typeof(IRepository<>), 
            typeof(IRepository<>).Assembly);
    var registrations =
        from type in repositoryTypes
        from @interface in type.GetInterfaces()
        where @interface.IsGenericType
        where @interface.GetGenericTypeDefinition() ==
            typeof(IRepository<>)
        select new { Service = @interface, Impl = type };

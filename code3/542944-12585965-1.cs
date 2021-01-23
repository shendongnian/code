    var assembly = Assembly.LoadFrom(
        ConfigurationManager.AppSettings["RepositoryAssembly"]);
    // Unity misses a batch-registration feature, so you'll have to
    // do this by hand.
    var repositoryRegistrations =
        from type in assembly.GetExportedTypes()
        where !type.IsAbstract
        where !type.IsGenericTypeDefinition
        let repositoryInterface = (
            from _interface in type.GetInterfaces()
            where _interface.IsGenericType
            where typeof(IRepository<>).IsAssignable(
                _interface.GetGenericTypeDefinition())
            select _interface)
            .SingleOrDefault()
        where repositoryInterface != null
        select new
        {
            service = repositoryInterface, 
            implemention = type
        };
    foreach (var reg in repositoryRegistrations)
    {
        container.RegisterType(reg.service, reg.implementation);
    }

    ObjectFactory.Initialize(c => c.Scan(scan =>
    {
        scan.TheCallingAssembly();
        scan.AddAllTypesOf<IHandleDomainService>();
    }));

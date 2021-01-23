    var types = ...
    container.RegisterAll<IInterface>(types);
    foreach (var type in types)
    {
        // Make sure you use the non-generic extension method from the
        // SimpleInjector.Extensions.dll.
        container.RegisterSingle(type, type);
    }

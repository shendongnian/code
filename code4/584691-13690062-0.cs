    var types = ...
    container.RegisterAll<IInterface>(types);
    foreach (var type in types)
    {
        container.RegisterSingle(type);
    }

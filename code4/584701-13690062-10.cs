    // using SimpleInjector.Extensions;
    Type[] singletons = FindAllTypesToRegister();
    foreach (Type type in singletons)
    {
        container.RegisterSingle(type, type);
    }
    container.RegisterAll(typeof(I1), singletons);
    container.RegisterAll(typeof(I2), singletons);

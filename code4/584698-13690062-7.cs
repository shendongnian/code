    // using SimpleInjector.Extensions;
    Type[] singletons = FindAllTypesToRegister();
    foreach (Type type in singletons)
    {
        // note: RegisterSingle(type) will not work, since the C# compiler
        // will use RegisterSingle<Type>(type) in that case which is not
        // what we want.
        container.RegisterSingle(type, type);
    }
    container.RegisterAll(typeof(I1), singletons);
    container.RegisterAll(typeof(I2), singletons);

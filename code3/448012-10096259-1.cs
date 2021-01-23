    // register all types in all modules
    protected override void ConfigureContainer()
    {
        base.ConfigureContainer();
        // ModuleA
        Container.RegisterType<IInterface1, Type1>();
        Container.RegisterType<IInterface2, Type2>();
        // ModuleB
        Container.RegisterInstance<IInterface3>("name", new Type3());
        Container.RegisterType<IInterface4, Type4>();
        // ModuleC
        Container.RegisterType<IInterface5, Type5>();
        Container.RegisterType<IInterface6, Type6>();
    }

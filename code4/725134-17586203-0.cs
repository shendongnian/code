    IUnityContainer container = new UnityContainer()
        .RegisterType<IRegisterAutoMapper, RegisterAutoMapper>() //default
        .RegisterType<IRegisterAutoMapper, MobileRegisterAutoMapper>("Mobile")
        .RegisterType<AutoMapperRegisterFactory>(
            new InjectionConstructor(
                typeof(IRegisterAutoMapper), 
                new ResolvedParameter<IRegisterAutoMapper>("Mobile")));

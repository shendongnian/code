    public static void RegisterTypes()
    {
        if (!initialized)
        {
            Kernel.Bind(scanner => scanner.FromAssembliesMatching("MyCompany.MyProduct.*")
                                   .SelectAllClasses()
                                   .BindDefaultInterface());
            
            //Try to add following line
            Kernel.Bind<IAlertManagement>().To<ConcreteImplementationOfIAlertManagement>();
            Kernel.Unbind(typeof(IWcfServiceClient<>));
            Kernel.Bind(typeof(IWcfServiceClient<>)).ToMethod(ctx => (ctx.Kernel.Get(typeof(WcfServiceClientProvider<>).MakeGenericType(ctx.GenericArguments)) as IProvider).Create(ctx)); 
        }
    
        initialized = true;
    }

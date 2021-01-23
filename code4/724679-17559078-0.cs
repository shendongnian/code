    IUnityContainer container = new UnityContainer();
    
    container.AddNewExtension<Interception>();
    
    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().Where(
            t => t.Namespace == "My.Namespace.Services"),
        WithMappings.MatchingInterface,
        getInjectionMembers: t => new InjectionMember[]
        {
            new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<MyBehavior>()
        });
    }

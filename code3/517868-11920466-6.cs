    var container = new UnityContainer();
    
    container.AddNewExtension<Interception>();
    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().Where(
          t => t.Namespace == "OtherUnitySamples"),
        WithMappings.MatchingInterface,
        getInjectionMembers: t => new InjectionMember[]
        {
          new Interceptor<VirtualMethodInterceptor>(),
          new InterceptionBehavior<LoggingInterceptionBehavior>()
        });

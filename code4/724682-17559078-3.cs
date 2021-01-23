    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().Where(
            t => t.Namespace == "My.Namespace.Services"),
        WithMappings.MatchingInterface,
        getInjectionMembers: t => new InjectionMember[]
        {
            new InterceptionBehavior<PolicyInjectionBehavior>(),
            new Interceptor<InterfaceInterceptor>(),
        });
    }
    container.Configure<Interception>()
        .AddPolicy("profiler")
        .AddMatchingRule<AssemblyMatchingRule>(
            new InjectionConstructor(
                new InjectionParameter("My.Namespace.Services")))
        .AddCallHandler<ProfilerHandler>(
            new ContainerControlledLifetimeManager());

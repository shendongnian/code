    unity.RegisterType<A, ConcreteAX>(new ContainerControlledLifetimeManager());
    unity.RegisterType<B, ConcreteBX>(new ContainerControlledLifetimeManager());
    unity.RegisterType<X, ConcreteAX>("AX", 
        new ExternallyControlledLifetimeManager(), 
        new InjectionFactory(u => u.Resolve<A>()));
    unity.RegisterType<X, ConcreteBX>("BX", 
        new ExternallyControlledLifetimeManager(), 
        new InjectionFactory(u => u.Resolve<B>()));

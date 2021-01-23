      // first named registration
      child1.RegisterType<ISimpleSessionFactory, NHibernateSessionFactory>(
                new ContainerControlledLifetimeManager(), 
                new InjectionConstructor("ConnectionA"), "ConnectionA");
      child1.RegisterType<IA1, A1>( new InjectionConstructor( new ResolvedParameter<ISimpleSessionFactory>("ConnectionA"));
      child1.RegisterType<R1>( new InjectionConstructor( new ResolvedParameter<ISimpleSessionFactory>("ConnectionA") );
      // the same goes for the second one, just create a named registration 
      // under a different name

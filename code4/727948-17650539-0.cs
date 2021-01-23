    interface IASessionFactory : ISimpleSessionFactory{}
    interface IBSessionFactory : ISimpleSessionFactory{}
    
    class ASessionFactory : NHibernateSessionFactory, IASessionFactory{...}
    class BSessionFactory : NHibernateSessionFactory, IBSessionFactory{...}
    
    var unity = new UnityContainer();
    
    unity.RegisterType<IASessionFactory, ASessionFactory>(
                    new ContainerControlledLifetimeManager(), new InjectionConstructor("ConnectionA"));
    
    unity.RegisterType<IBSessionFactory, BSessionFactory>(
                    new ContainerControlledLifetimeManager(), new InjectionConstructor("ConnectionB"));
    
    unity.RegisterType<IA1, A1>();
    unity.RegisterType<R1>();
    
    unity.RegisterType<IA2, A2>();
    unity.RegisterType<R2>();

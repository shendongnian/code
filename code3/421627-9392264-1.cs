    public override void Load() 
            { 
                Bind<ISessionFactory>().ToMethod(c => SessionFactory1.SessionFactory).InSingletonScope().Named("d1"); 
                Bind<ISessionFactory>().ToMethod(c => SessionFactory2.SessionFactory).InSingletonScope().Named("d2"); 
     
                Bind<ISession>().ToMethod(c => c.Kernel.Get<ISessionFactory>("d1").OpenSession()).Named("s1"); 
                Bind<ISession>().ToMethod(c => c.Kernel.Get<ISessionFactory>("d2").OpenSession()).Named("s2"); 
     
                Bind(typeof(IReadOnlyRepository<,>)).To(typeof(Repository<,>)).WithConstructorArgument("session", c => c.Kernel.Get<ISession>("s1")).Named("r1"); 
                Bind(typeof(IReadOnlyRepository<,>)).To(typeof(Repository<,>)).WithConstructorArgument("session", c => c.Kernel.Get<ISession>("s2")).Named("r2"); 
            } 
    IReadOnlyRepository repository1 = kernel.Get<IReadOnlyRepository>("r1");

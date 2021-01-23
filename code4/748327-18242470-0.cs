    container.RegisterType<IRepository, Repository>("GlobalContext",
        new InjectionConstructor(
            new ResolvedParameter<INHibernateContext>("GlobalContext"),
            new ResolvedParameter<ISession>("GlobalContext")
        )
    );

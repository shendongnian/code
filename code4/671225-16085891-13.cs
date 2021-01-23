    public static class BootStrapper
    {
        public static void Configure(Container container)
        {
            var lifetimeScope = new LifetimeScopeLifestyle();
            container.Register<IUnitOfWork, UnitOfWork>(lifetimeScope);
            container.RegisterManyForOpenGeneric(
                typeof(IRepository<>),
                lifetimeScope,
                typeof(IRepository<>).Assembly);
        }
    }

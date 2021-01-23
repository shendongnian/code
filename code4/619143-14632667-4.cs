    container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
    container.Register<IDatabaseFactory, DatabaseFactory>(Lifestyle.Scoped);
    container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
    container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
    container.Register<ICategoryService, CategoryService>(Lifestyle.Scoped);

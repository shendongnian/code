    Lifestyle lifestyle = new WebRequestLifestyle();
    container.Register<IDatabaseFactory, DatabaseFactory>(lifestyle);
    container.Register<IUnitOfWork, UnitOfWork>(lifestyle);
    container.Register<ICategoryRepository, CategoryRepository>(lifestyle);
    container.Register<ICategoryService, CategoryService>(lifestyle);

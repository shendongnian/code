    container.RegisterPerWebRequest<IObjectContextAdapter, MyDbContext>();
    container.RegisterPerLifetimeScope<DbContext, MyDbContext>();
    // Register as hybrid PerWebRequest / PerLifetimeScope.
    container.Register<MyDbContext>(() =>
    {
        if (HttpContext.Current != null)
            return (MyDbContext)container.GetInstance<IObjectContextAdapter>();
        else
            return (MyDbContext)container.GetInstance<DbContext>();
    });

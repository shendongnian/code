    container.RegisterPerWebRequest<IWebUoW, DiUnitOfWork>();
    container.RegisterPerLifetimeScope<IScopeUoW, DiUnitOfWork>();
    // Register as hybrid PerWebRequest / PerLifetimeScope.
    container.Register<IUnitOfWork>(() =>
    {
        if (HttpContext.Current != null)
            return container.GetInstance< IWebUoW >();
        else
            return container.GetInstance< IScopeUoW >();
    });

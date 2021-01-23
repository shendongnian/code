    container.RegisterPerWebRequest<DiUnitOfWork>();
    container.RegisterLifetimeScope<IScopeUnitOfWork, DiUnitOfWork>();
    // Register as hybrid PerWebRequest / PerLifetimeScope.
    container.Register<IUnitOfWork>(() =>
    {
        if (HttpContext.Current != null)
            return container.GetInstance<DiUnitOfWork>();
        else
            return container.GetInstance<IScopeUnitOfWork>();
    });

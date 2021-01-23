    private static void AddWebApiSupport(StandardKernel kernel)
    {
      // Support WebAPI
      GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
      GlobalConfiguration.Configuration.Services.Add(typeof(IFilterProvider), new NinjectWebApiFilterProvider(kernel));
    }

    private static IKernel CreateKernel()
    {
    	var kernel = new StandardKernel();
    	kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
    	kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
    	
    	// register all your dependencies on the kernel container
    	RegisterServices(kernel);
    
    	// register the dependency resolver passing the kernel container
    	GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
    		
    	return kernel;
    }

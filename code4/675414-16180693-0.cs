    public static IContainer Initialise() 
    { 
        builder = new ContainerBuilder(); 
    	builder.RegisterControllers(typeof(MvcApplication).Assembly); 
    	Register types here builder.Register(x => new FormsAuthWrapper()).As<IFormsAuthentication>();
    	builder.Register(x => new ServiceDbContext()).As<DbContext>().As<ServiceDbContext>().InstancePerHttpReques‌​t();
    	var container = builder.Build(); 
    	DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
    	return container;
    } 

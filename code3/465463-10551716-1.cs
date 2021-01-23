  	var builder = new ContainerBuilder();
        builder.Register(service => new CustomerService()).As<ICustomerService>().InstancePerHttpRequest();
        builder.RegisterControllers(typeof(MvcApplication).Assembly);
        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

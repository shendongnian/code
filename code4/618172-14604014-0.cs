	var assembly = Assembly.GetExecutingAssembly();
	builder
		.RegisterAssemblyTypes(assembly)
		.AssignableTo<IQuery>()
		.AsImplementedInterfaces()
		.InstancePerRequest();
		

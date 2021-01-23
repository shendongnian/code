    // Note: this isn't unity syntax, but I hope my point is clear
	container.Register<ISessionFactory, ReusableSessionFactory>("Reusable");
	container.Register<ISessionFactory, FreshSessionFactory>("Fresh");
	container.Register<IController, LoginController>().With("Fresh");
	container.Register<IController, HomeController>().With("Reusable");
	

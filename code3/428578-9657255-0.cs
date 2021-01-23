	// Get the IRepository which should be shared	
	// This object is registered using simple
	// For<ISession>.Use<Session> registration so not scoped
	// http context or anything like that
	var session = container.GetInstance<ISession>();
	
	// Create instance of IProcessor using the specific instance
	// of ISession. If multiple classes in the object grap use ISession
	// they will get the same instance. Note that you can use multiple
	// With() statements
	var itemProcessor = container.With(session).GetInstance<IItemProcessor>();

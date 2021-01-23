	// Create the real service factory
	IMyServiceFactory svcFactory = /* ... */ ;
	// Create the service proxy
	MyDynamicDecoratedServiceFactory svcProxyFactory 
		= new MyDynamicDecoratedServiceFactory(svcFactory);
	IMyService svcProxy = svcProxyFactory.Create();
	// Use it!
	svcProxy.A();

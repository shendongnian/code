	// Create a service factory (the to-be-decorated class)
	IMyServiceFactory myRealServiceFactory = /* ... */;
	// Create a factory that will create decorated services
	MyServiceClientInterceptor interceptor = 
            new MyServiceClientInterceptor(myRealServiceFactory);
	MyDynamicallyDecoratedServiceClientFactory svcFactory =  
            new MyDynamicallyDecoratedServiceClientFactory(interceptor);
	// Create a service client
	IMyService svc = svcFactory.Create();
	// Use it!
	svcProxy.A();

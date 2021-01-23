    builder.Register(x =>
	{
		ILifetimeScope scope = x.Resolve<ILifetimeScope>().BeginLifetimeScope();
		MyHub hub = new MyHub(scope.Resolve<IMyDependency>());
		hub.OnDisposing += scope.Dispose;
		return hub;
	})
	.As<MyHub>().InstancePerDependency();

    public class FooFactory : IFooFactory
	{
		// allows us to Get things from the kernel, but not add new bindings etc.
		private readonly IResolutionRoot resolutionRoot;
		
		public FooFactory(IResolutionRoot resolutionRoot)
		{
			this.resolutionRoot = resolutionRoot;
		}
		
		public IFoo CreateFoo()
		{
			return this.resolutionRoot.Get<IFoo>();
		}
		
		// or if you want to specify a value at runtime...
		
		public IFoo CreateFoo(string myArg)
		{
			return this.resolutionRoot.Get<IFoo>(new ConstructorArgument("myArg", myArg));
		}
	}
	
	public class Foo : IFoo { ... }
	
	public class NeedsFooAtRuntime
	{
		public NeedsFooAtRuntime(IFooFactory factory)
		{
			this.foo = factory.CreateFoo("test");
		}
	}
	
	Bind<IFooFactory>().To<FooFactory>();
	Bind<IFoo>().To<Foo>();

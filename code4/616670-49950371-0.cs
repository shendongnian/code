	// Register the UnityContainer with itself
	container.RegisterInstance<IUnityContainer>(container);
	public class A
	{
		public A(B b) {}
	}
	public class B
	{
		public B(C c) {}
	}
	public class C
	{
		private readonly IUnityContainer _container;
		private A _a => _container.Resolve<A>();
		
		public C(IUnityContainer container) {
			_container = container;
		}
	}

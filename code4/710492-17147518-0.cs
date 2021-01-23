	public class ServiceClass
	{
		private readonly IPropertyClassFactory factory;
		public PropertyClass Property { get; private set; }
		public ServiceClass(IPropertyClassFactory factory)
		{
			this.factory = factory;
		}
		public void Action()
		{
			Property = factory.CreateInstance();
			Property.DoSomething();
		}
	}

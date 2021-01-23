	public class SomeClassToResolve
	{
		private readonly ServiceA _serviceA;
		private readonly ServiceB _serviceB;
		public SomeClassToResolve(ServiceA serviceA, ServiceB serviceB)
		{
			_serviceA = serviceA;
			_serviceB = serviceB;
		}
	}

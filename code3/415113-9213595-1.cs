	public static class Factory
	{
		public static T Get<T>()
			where T: InterfaceBase
		{
			if (typeof(Interface1).IsAssignableFrom(typeof(T))
			{
				return (T)(new Concrete1());
			}
			...
			else if (typeof(InterfaceX).IsAssignableFrom(typeof(T))
			{
				return (T)(new ConcreteX());
			}
		}
	}

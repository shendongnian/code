	interface ISomeInterface
	{
		string CommonProperty { get; }
	}
	class B : ISomeInterface
	{
		public string CommonProperty { get; }
	}
	class D : ISomeInterface
	{
		public string CommonProperty { get; }
	}
	ISomeInterface[] array = new ISomeInterface[]
	{
		o1,
		o2,
		o3,
		o4
	}

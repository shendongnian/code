	interface IFoo<out B> where B:IBar
	{
		B MyBar { get; }
	}
	
	interface IBar
	{
		String Test { get; }
	}
	
	class Foo : IFoo<Bar>
	{
		public Bar MyBar { get; set; }
	}
	
	class Bar : IBar
	{
		public String Test { get; set; }
	}

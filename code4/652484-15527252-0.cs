    public interface IFoo
	{
		string Name { get; }
		string ToXml();
		IFooFactory FooFactory { get; }
	}
	public interface IFooFactory
	{
		IFoo Parse(string xml);
	}

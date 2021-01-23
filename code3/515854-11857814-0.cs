	public interface IPrimitive
	{
		object Value { get; }
	}
	
	public interface IPrimitive<T> : IPrimitive
	{
		new T Value { get; }
	}
	
	public class Star : IPrimitive<string> //must declare T here
	{
		public string Value { get { return "foobar"; } }
		object IPrimitive.Value { get { return this.Value; } }
	}
	
	public class Sun : IPrimitive<int>
	{
		public int Value { get { return 0; } }
		object IPrimitive.Value { get { return this.Value; } }
	}

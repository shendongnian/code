	// Non-generic
	public class Response
	{
		public object Value { get; private set; }
	}
	// Generic
	public class Response<T> : Response
	{
		public new T Value { get; set; }
	}
	
	public static void Main()
	{
		List<Response> List = new List<Response>() { new Response<int>() { Value = 1 }, new Response<string>() { Value = "p" } };
		// Throws NullReferenceException
		Console.WriteLine(list[0].Value);
		Console.WriteLine(list[1].Value);
	}

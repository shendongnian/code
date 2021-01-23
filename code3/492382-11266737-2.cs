	// Non-generic
	public class Response
	{
		protected object valueObject;
		
		public object Value
		{
			get
			{
				return valueObject;
			}
		}
	}
	// Generic
	public class Response<T> : Response
	{
		public new T Value
		{
			get
			{
				return (T)valueObject;
			}
			set
			{
				valueObject = value;
			}
		}
	}
	
	public static void RunSnippet()
	{
		List<Response> list = new List<Response>() { new Response<int>() { Value = 1 }, new Response<string>() { Value = "p" } };
		
		Console.WriteLine(list[0].Value);
		Console.WriteLine(list[1].Value);
	}

	class Program
	{
		static void Main(string[] args)
		{
			var reference = MyClass.property;
		}
	}
	class MyClass
	{
		public static string property { get; set; }	
	}

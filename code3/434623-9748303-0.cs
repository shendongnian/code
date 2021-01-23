    //abstraction
	interface IStringExtensions
	{
		bool IsNullOrWhiteSpace(string input);
		bool IsNullOrEmpty(string input);
	}
	//implementation
	class StringExtensionsImplementation : IStringExtensions
	{
		public bool IsNullOrWhiteSpace(string input)
		{
			return String.IsNullOrWhiteSpace(input);
		}
		public bool IsNullOrEmpty(string input)
		{
			return String.IsNullOrEmpty(input);
		}
	}
	//extension class
	static class StringExtensions
	{
		//default implementation
		private static IStringExtensions _implementation = new StringExtensionsImplementation();
		//implementation injectable!
		public static void SetImplementation(IStringExtensions implementation)
		{
			if (implementation == null) throw new ArgumentNullException("implementation");
			_implementation = implementation;
		}
		//extension methods
		public static bool IsNullOrWhiteSpace(this string input)
		{
			return _implementation.IsNullOrWhiteSpace(input);
		}
		public static bool IsNullOrEmpty(this string input)
		{
			return _implementation.IsNullOrEmpty(input);
		}
	}

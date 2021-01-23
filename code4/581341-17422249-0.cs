	// contains static methods to help with strings
	public static class StringTools
	{
		public static IEnumerable<string> DoSomething(params string[] args)
		{
			// do something
		}
	}
	// contains only extension methods
	public static class StringToolsExtensions
	{
		public static IEnumerable<string> DoSomething(this string[] args)
		{
			return StringTools.DoSomething(args);
		}
	}

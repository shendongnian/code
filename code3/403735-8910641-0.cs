    namespace SomeNamespace
    {
    	public static class StringExtensions
    	{
    		public static bool Contains(this string source, string toCheck, StringComparison comp)
    		{
    			return source.IndexOf(toCheck, comp) >= 0;
    		}
    	}
    }
    // ... In some other class ...
    using SomeNamespace;
    
    // ...
    bool contains = "hello".Contains("ll", StringComparison.OrdinalIgnoreCase);

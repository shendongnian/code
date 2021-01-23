    public static void Main(string[] args)
    {
    	int? a = null;
    	string b = "my string";
    	object c = null;
    	Console.WriteLine(a.MyToString());
    	Console.WriteLine(b.MyToString());
    	Console.WriteLine(c.MyToString());
    }
    public static class DecoratorExtensions
    {
    	const string MY_DEFAULT = "default";
    
    	public static string MyToString<T>(this T obj, string myDefault = MY_DEFAULT) where T : class
    	{
    		return obj == null ? myDefault : obj.ToString();
    	}
    	public static string MyToString<T>(this T? nullable, string myDefault = MY_DEFAULT) where T : struct
    	{
    		return !nullable.HasValue ? myDefault : nullable.Value.ToString();
    	}
    }

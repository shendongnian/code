    public static void Main(string[] args)
    {
    	int? a = null;
    	string b = "my string";
    	object c = null;
    	// prints empty 
    	Console.WriteLine(a.MyToString());
    	// prints my string
    	Console.WriteLine(b.MyToString());
    	// prints empty
    	Console.WriteLine(c.MyToString());
    	// prints variable a doesn't have a value either
    	Console.WriteLine(c.MyToString(callback: () => !a.HasValue ? "variable a doesn't have a value either" : DecoratorExtensions.MY_DEFAULT));
    }
    
    public static class DecoratorExtensions
    {
    	public const string MY_DEFAULT = "empty";
    
    	public static string MyToString<T>(this T obj, string myDefault = MY_DEFAULT, Func<string> callback = null) where T : class
    	{
    		if (obj != null) return obj.ToString();
    		return callback != null ? callback() : myDefault;
    	}
    
    	public static string MyToString<T>(this T? nullable, string myDefault = MY_DEFAULT, Func<string> callback = null) where T : struct
    	{
    		if (nullable.HasValue) return nullable.Value.ToString();
    		return callback != null ? callback() : myDefault;
    	}
    }

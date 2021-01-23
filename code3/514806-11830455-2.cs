    private static void Main(string[] args)
    {
    	MrResult r = new MrResult
    	{
    		Owner = string.Empty,
    		Description = string.Empty
    	};
    
    	foreach (var property in r.GetType().GetProperties())
    	{
    		if (property.PropertyType == typeof(string) && property.CanWrite)
    		{
    			string propertyValueAsString = (string)property.GetValue(r, null);
    			property.SetValue(r, propertyValueAsString.NullIfEmpty(), null);
    		}
    	}
    
    	Console.ReadKey();
    }

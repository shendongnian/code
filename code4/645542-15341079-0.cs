    static void ShowProperties(object o, int indent = 0)
    {
    	foreach (var prop in o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
    	{
    		if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
    		{
    			Console.WriteLine("{0}{1}:", string.Empty.PadRight(indent), prop.Name);
    			var coll = (IEnumerable)prop.GetValue(o, null);
    			if (coll != null)
    			{
    				foreach (object sub in coll)
    				{
    					ShowProperties(sub, indent + 1);
    				}
    			}
    		}
    		else
    		{
    			Console.WriteLine("{0}{1}: {2}", string.Empty.PadRight(indent), prop.Name, prop.GetValue(o, null));
    		}
    	}
    	Console.WriteLine("{0}------------", string.Empty.PadRight(indent));
    }

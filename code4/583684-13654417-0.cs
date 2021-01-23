    foreach (object o in values)
    {
    	Type t = o.GetType();
    	if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
    	{
    		string str = DoStuff((dynamic)o);
    		Console.WriteLine(str);
    	}
    }

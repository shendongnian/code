    foreach (object o in values)
    {
    	Type t = o.GetType();
    	if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
    	{
    		var typeParams = t.GetGenericArguments();
    		var method = typeof(ContainingType).GetMethod("DoStuff").MakeGenericMethod(typeParams);
    		string str = (string)method.Invoke(null, new[] { o });
    	}
    }

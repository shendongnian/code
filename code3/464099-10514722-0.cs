    static void PrintObjectHierarchy(object o)
    {
    	Type t = o.GetType();
    	while (t != null)
    	{
    		Console.WriteLine(t.FullName);
    		t = t.BaseType;
    	}
    }

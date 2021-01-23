	public static void Main()
	{
		UnknownArgumentsMethod1(1, 2, 3, "foo");
	}
	public static void UnknownArgumentsMethod1(params object[] list)
	{
		UnknownArgumentsMethod2(list);
	}
	public static void UnknownArgumentsMethod2(params object[] list)
	{
		foreach (object o in list)
		{
			if (o.GetType() == typeof(int))
			{
				Console.WriteLine("This is an integer: " + (int)o);
			}
			else if (o.GetType() == typeof(string))
			{
				Console.WriteLine("This is a string: " + (string)o);
			}
		}
	}

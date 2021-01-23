	public static void Main ()
	{
		var _someClass = new SomeClass2();
		var someClass = new SomeClass("aaa", "bbb");
		_someClass.Add(someClass);
		try
		{
			_someClass.Remove(someClass); 
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

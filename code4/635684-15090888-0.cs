	public void MyMethod(params string[] args)
	{
		MyMethod((IEnumerable<string>)args);
	}
	
	public void MyMethod(IEnumerable<string> args)
	{
		// ...
	}
	

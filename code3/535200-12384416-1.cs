	public void YourMethod(List<BaseClass> list, ...other params)
	{
		// ...
		
		foreach(var bc in list)
		{
			// so you don't need to know specific properties of concrete classes...
			bc.DoSomethingUsingProperties();
		}
		
		//...
	}

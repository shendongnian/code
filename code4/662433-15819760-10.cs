	dynamic dynObject = new ExpandoObject();
	dynObject.SomeDynamicProperty = "Hello!";
	dynObject.SomeDynamicAction = (msg) =>
		{
			Console.WriteLine(msg);
		};
	
	dynObject.SomeDynamicAction(dynObject.SomeDynamicProperty);
	

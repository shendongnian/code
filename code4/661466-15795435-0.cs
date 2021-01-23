	asm = Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, filePath));
	
	Type[] types = asm.GetTypes();
	for (var x = 0; x < types.Length; x++)
	{
		var interfaces = types[x].GetInterfaces();
		for (var y = 0; y < interfaces.Length; y++)
		{
	        if (interfaces[y].Name.Equals("MyTypeName"))
			{
				isValidmod = true;
				var p = (IMyType)Activator.CreateInstance(types[x]);
                                //Other stuff
		        }
		}
	

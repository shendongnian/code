	var type = "System.String";
	var reallyAString = Activator.CreateInstance(
            // need a Type here, so get it by type name
            Type.GetType(type), 
            // string's has no parameterless ctor, so use the char array one
            new char[]{'a','b','c'});
	Console.WriteLine(reallyAString);
	Console.WriteLine(reallyAString.GetType().Name);

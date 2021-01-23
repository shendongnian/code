	var dict = new Dictionary<string, object>();
	
	var isDict = typeof(IDictionary).IsAssignableFrom(dict.GetType());
	
	Console.WriteLine(isDict); //prints true

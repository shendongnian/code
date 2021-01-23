	public void MyMethod(params object[] args)
	{
		object[] flattened = arg
			// For each element that is not in an array, put it in an array.
			.Select(a => a is object[] ? (object[])a : new object[] { a })
			// Select each element from each array.
			.SelectMany(a => a)
			// Make the resulting sequence into an array.
			.ToArray();
		// ...
	}
	
	MyMethod(var1, var2);

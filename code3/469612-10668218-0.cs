    var dictionary = new Dictionary<string, int>()
	{
	    {"mac", 1000},
	    {"windows", 500}
	};
	// Use ContainsKey method.
	if (dictionary.ContainsKey("mac") == true)
	{
	    Console.WriteLine(dictionary["mac"]); // <-- Is executed
	}
	// Use ContainsKey method on another string.
	if (dictionary.ContainsKey("acorn"))
	{
	    Console.WriteLine(false); // <-- Not hit
	}

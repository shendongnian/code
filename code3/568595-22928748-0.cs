       string[] array = { "cat", "dot", "perls" };
	// Use Array.Exists in different ways.
	bool a = Array.Exists(array, element => element == "perls");
	bool b = Array.Exists(array, element => element == "python");
	bool c = Array.Exists(array, element => element.StartsWith("d"));
	bool d = Array.Exists(array, element => element.StartsWith("x"));
	// Display bools.
	Console.WriteLine(a);
	Console.WriteLine(b);
	Console.WriteLine(c);
	Console.WriteLine(d);
    ----------------------------output-----------------------------------

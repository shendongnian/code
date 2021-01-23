	var messages = new []
	{
		"Hello",
		"Goodbye",
	};
	
	messages.IfBounded(-1, t => Console.WriteLine(t));
	messages.IfBounded(0, t => Console.WriteLine(t));
	messages.IfBounded(1, t => Console.WriteLine(t));
	messages.IfBounded(2, t => Console.WriteLine(t));

	source.Buffer(2)
		.Select(i =>
	{
		Console.WriteLine("Start Processing Buffer");
		Task.WhenAll(from n in i select DoUpload(n)).Wait();
		Console.WriteLine("Finished Processing Buffer");
		return Unit.Default;
	}).Subscribe();

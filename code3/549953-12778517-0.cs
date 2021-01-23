	List<String> input = File.ReadAllLines().ToList<String>(); // or whatever
	var output = new Dictionary<String, String>();
	foreach (String line in input)
	{
		var parts = input.Split('@');
		
		output.Add(parts[0], parts[1]);
	}
	foreach (var feature in output)
	{
		Console.WriteLine("{0}: {1}", feature.Key, feature.Value);
	}

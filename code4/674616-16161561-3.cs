	void Main()
	{
		var counts = GetCount(new [] {
			"Hello there!",
   			"It's the best site ever!"
		});
		Console.WriteLine(counts);
	}
	public IDictionary<string, int> GetCount(IEnumerable<string> inputs)
	{
		var allWords = 	    from input in inputs
							let matches = Regex.Matches(input, "[A-Za-z']+")
							from x in matches.OfType<System.Text.RegularExpressions.Match>()
							select x.Value;
		var occurences = allWords.GroupBy(x => x, (x, y) => new{Key = x, Count = y.Count()}, StringComparer.OrdinalIgnoreCase);
							
		var result = occurences.ToDictionary(x => x.Key, x => x.Count, StringComparer.OrdinalIgnoreCase);
		return result;
	}

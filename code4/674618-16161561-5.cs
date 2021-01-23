	void Main()
	{
		var counts = GetCount(new [] {
			"Hello there!",
   			"It's the best site ever!"
		});
		Console.WriteLine(counts);
	}
	public IDictionary<string, int> GetCount(IEnumerable<Foo> inputs)
	{
		var allWords = 	    from input in inputs
							let matchesA = Regex.Matches(input.A, "[A-Za-z']+").OfType<System.Text.RegularExpressions.Match>()
							let matchesB = Regex.Matches(input.B, "[A-Za-z']+").OfType<System.Text.RegularExpressions.Match>()
							from x in matchesA.Concat(matchesB)
							select x.Value;
		var occurences = allWords.GroupBy(x => x, (x, y) => new{Key = x, Count = y.Count()}, StringComparer.OrdinalIgnoreCase);
							
		var result = occurences.ToDictionary(x => x.Key, x => x.Count, StringComparer.OrdinalIgnoreCase);
		return result;
	}

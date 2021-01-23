	void Main()
	{
		var a = "Hello there!";
		var b =  "It's the best site ever!";
		
		var ab = a + b;
		
		var matches = Regex.Matches(ab, "[A-Za-z]+");
		var occurences = from x in matches.OfType<System.Text.RegularExpressions.Match>()
						let word = x.Value.ToLowerInvariant()
						group word by word into g
						select new { Word = g.Key, Count = g.Count() };
		var result = occurences.ToDictionary(x => x.Word, x => x.Count);
		Console.WriteLine(result);
	}

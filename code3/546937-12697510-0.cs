		int iterations = 1000000;
		int result = 0;
		string s= "   \t  Test";
		 
		System.Diagnostics.Stopwatch watch = new Stopwatch();
		// Convert to char array and use FindIndex
		watch.Start();
		for (int i = 0; i < iterations; i++)
			result = Array.FindIndex(s.ToCharArray(), x => !char.IsWhiteSpace(x)); 
		watch.Stop();
		Console.WriteLine("Convert to char array and use FindIndex: " + watch.ElapsedMilliseconds);
		// Trim spaces and get index of first character
		watch.Restart();
		for (int i = 0; i < iterations; i++)
			result = s.IndexOf(s.TrimStart().Substring(0,1));
		watch.Stop();
		Console.WriteLine("Trim spaces and get index of first character: " + watch.ElapsedMilliseconds);
		// Use extension method
		watch.Restart();
		for (int i = 0; i < iterations; i++)
			result = s.IndexOf<char>(c => !char.IsWhiteSpace(c));
		watch.Stop();
		Console.WriteLine("Use extension method: " + watch.ElapsedMilliseconds);

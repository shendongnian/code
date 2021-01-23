	var kw = new KeywordWatcherStreamWrapper(Console.Out, "Hello");
	kw.KeywordFound += (s, e) => { throw new Exception("Keyword found!"); };
	try {	
		Console.SetOut(kw);
		Console.WriteLine("Testing");
		Console.WriteLine("Hel");
		Console.WriteLine("lo");
		Console.WriteLine("Hello");
		Console.WriteLine("Final");
	} catch (Exception ex) { Console.Write(ex.Message); }

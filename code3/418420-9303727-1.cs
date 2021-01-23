	string[] Patterns = new[] { "AB:CDE", "BA:D", "CA:EFG", "DE:ABEFG" };
	string Field1 = "C";
	string Field2 = "A";
	string Field3 = "FG";
	
	string[] Results = MatchPatterns(Patterns, Field1, Field2, Field3);
	
	Console.WriteLine("Matching patterns:");
	foreach (string r in Results)
	    Console.WriteLine(r);
	
	private string[] MatchPatterns(string[] patterns, string f1, string f2, string f3)
	{
		return patterns.Where(c => f1 == c.Substring(0, 1) && f2 == c.Substring(1, 1) && c.Substring(3).Contains(f3)).ToArray();
	}

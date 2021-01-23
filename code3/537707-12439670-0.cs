string[] sArray = new string[]
	{
		"rose with ribbon",
		"roses on bed",
		"roses in concrete"
	};
Regex re = new Regex("\\bon\\b");
foreach (string s in sArray)
{
	Console.Out.WriteLine("{0} match? {1}", s, re.IsMatch(s));
	Match m = re.Match(s);
	foreach(Group g in m.Groups)
	{
		if (g.Success)
		{
			Console.Out.WriteLine("Match found at position {0}", g.Index);
		}
	}
}

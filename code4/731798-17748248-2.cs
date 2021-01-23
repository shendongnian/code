	static void Main()
	{
		string input = "[MyAppTerms.TermName1]. [MyAppTerms.TermName2]. 1- [MyAppTerms.TermNameX] 2";
		Regex regex = new Regex(@"\[MyAppTerms\.([^\]]+)\]");
		string output = regex.Replace(input, m => ReadTerm(m.Groups[1].Value));
		Console.WriteLine(output);
	}

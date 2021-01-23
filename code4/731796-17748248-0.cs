	static void Main()
	{
        string input = "[MyAppTerms.TermName1]. [MyAppTerms.TermName2]. 1- [MyAppTerms.TermNameX] 2";
		Regex regex = new Regex(@"\[MyAppTerms\.([^\]]+)\]");
        string output = regex.Replace(input, new MatchEvaluator(RegexReadTerm));
        System.Console.WriteLine(output);
	}
    static string RegexReadTerm(Match m)
    {
		// The term name is captured in the first group
        return ReadTerm(m.Groups[1].Value);
    }

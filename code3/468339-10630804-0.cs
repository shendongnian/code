    static void Main(string[] args)
    {
        matchRegex("\"MYSQL,ORACLE\",\"C#,ASP.NET\"").ForEach(Console.WriteLine);
        matchRegex("\"MYSQL,ORACLE\", \"C#,ASP.NET\"").ForEach(Console.WriteLine);
    }
    static List<string> matchRegex(string input)
    {
        List<string> strNewSplit = new List<string>();
        Regex csvSplit = new Regex(
            "(\"(?:[^\"]*)\")"
            , RegexOptions.Compiled);
        foreach (Match match in csvSplit.Matches(input))
        {
           strNewSplit.Add(match.Value.TrimStart(','))
        }
        return strNewSplit;
    }

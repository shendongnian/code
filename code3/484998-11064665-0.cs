    public static void Test1()
    {
        string sText = "this {is}  a {test}";
        Regex oRegExp = new Regex(@"{([^\}]+)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        MatchCollection oMatches = oRegExp.Matches(sText);
        foreach (Match Text in oMatches)
        {
            Console.WriteLine(Text.Value.Substring(1));
        }
    }

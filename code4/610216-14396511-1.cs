    static string RandomReplacer(Match m)
    {
        var result = new StringBuilder();
        foreach (char c in m.ToString())
            result.Append(c == 'd' ? RandomDigit() : c);
        return result.ToString()
    }
    private static string parseTemplate(string template)
    {
        return Regex.Replace(template, @"(\[d)((:)?([\d]+)?)\]", new MatchEvaluator(RandomReplacer));
    }

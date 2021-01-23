    using System.Text.RegularExpressions;
    
    private string ExtractString(string sourceString)
    {
        // (?<=string) is positive look-behind where you search for string before the match.
        // .* is all characters in between.
        // (?=string) is positive look-ahead where you search for string after the match.
        string pattern = "(?<=<a.*?>).*(?=</a)";
        Match match = Regex.Match(sourceString, pattern);
        return match.Value;
    }

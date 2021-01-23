    using System.Text.RegularExpressions;
    private string ParseString(string originalString)
    {
        string pattern = ".*(?=Result:.*)";
        Match match = Regex.Match(originalString, pattern);
        return match.Value;
    }

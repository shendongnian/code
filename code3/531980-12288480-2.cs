    using System.Text.RegularExpressions;
    private string GetLetter(string fileName)
    {
        string pattern = "\S(?=\s*?Final)";
        Match match = Regex.Match(fileName, pattern);
        return match.Value;
    }

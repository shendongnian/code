    string pattern = @"(?<Value>RewrittenQuery:[^\n\r]+\s)(?:adjust:)";
    RegexOptions regexOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline;
    Regex regex = new Regex(pattern, regexOptions);
    string targetString = @"RewrittenQuery: Word:(\""state\"" \""states\"" \""state s\"") Word:(\""library\"" \""libraries\"" \""libr\"" \""lib\"" \""lbry\"") adjust:1feature:#:\"" _MetaTag_Category 11265\""\r\n";
    foreach (Match match in regex.Matches(targetString))
    {
        if (match.Success)
        {
            var value = match.Groups["Value"];
        }
    }

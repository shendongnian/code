    String pattern = @"(?<=<p.*>).*(?=</p>)";
    var matches = Regex.Matches(text, pattern);
    StringBuilder result = new StringBuilder();
    result.Append("<p>");
    foreach (Match match in matches)
    {
        result.Append(match.Value);
    }
    result.Append("</p>");

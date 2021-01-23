    // escape RegEx special characters
    var pattern = Regex.Escape(likePattern);
    // convert negative character lists into RegEx negative character classes
    pattern = Regex.Replace(pattern, @"\\\[!(?<c>[^\]]*)\\\]", @"[^${c}]", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
    // convert positive character lists into RegEx positive character classes
    pattern = Regex.Replace(pattern, @"\\\[(?<c>[^\]]*)\\\]", @"[${c}]", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
    // convert asterisks into RegEx pattern for zero or more characters
    pattern = Regex.Replace(pattern, @"(?<!\[[^\]]*)\\*(?![^\]*\])", @".*", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
    // convert question marks into RegEx pattern for any single character
    pattern = Regex.Replace(pattern, @"(?<!\[[^\]]*)\\?(?![^\]*\])", @".", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
    // convert hash/number sign into RegEx pattern for any single digit (0 - 9)
    pattern = Regex.Replace(pattern, @"(?<!\[[^\]]*)#(?![^\]*\])", @"[0-9]", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
    // make pattern match whole string with RegEx start and end of string anchors
    pattern = @"^" + pattern + @"$";
    // perform "like" comparison
    return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

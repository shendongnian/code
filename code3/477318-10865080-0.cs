    // Presumably you'll be using the same regular expression every time, so
    // we might as well just create it once...
    private static readonly Regex Digits = new Regex(@"\d+");
    ...
    Match match = Digits.Match(text);
    if (match.Success)
    {
        string value = match.Value;
        // Take the length or whatever
    }

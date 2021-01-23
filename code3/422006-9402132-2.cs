    // "Traditional" way
    LocalTime time;
    if (LocalTime.TryParseExact(text, "h:mmtt", out time))
    {
        ...
    }
    // Preferred way
    private static readonly LocalTimePattern TimePattern = 
        LocalTimePattern.CreateWithInvariantInfo("h:mmtt");
    ...
    ParseResult<LocalTime> parseResult = TimePattern.Parse(text);
    if (parseResult.Success)
    {
        LocalTime time = parseResult.Value;
        ...
    }

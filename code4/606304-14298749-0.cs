    var match = spanRegex.Match(normalizedText);
    // TODO: Handle !match.Success for parsing errors here.
    var drawNumberString = match.Groups["DrawNumber"].Value.Trim();
    var timestampString = match.Groups["Timestamp"].Value.Trim();
    
    int drawNumber;
    DateTime timestamp;
    
    if(!int.TryParse(drawNumberString, out drawNumber))
    {
      // TODO: Handle draw number parsing errors here.
    }
    if(!DateTime.TryParse(timestampString, out timestamp))
    {
      // TODO: Handle timestamp parsing errors here.
    }

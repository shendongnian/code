    var parsedFileData = new List<Metrics>();
    
    while (!streamReader.EndOfStream)
    {
        var line = streamReader.ReadLine();
        if(IsLineNeedToBeParsed(line))
            parsedFileData.Add(ParseLine(line));
    } 

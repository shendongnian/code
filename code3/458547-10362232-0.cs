    # Read next line from file
    String line = readNextLineFromYourFile();
    # Store the parsed line in a list of strings
    List<String> parsedLine = new List<String>();
    # Extract fixed width parts of the line, trim away whitespace and store in parsed line
    parsedLine.Add(line.Substring(0,1).Trim());
    parsedLine.Add(line.Substring(1,5).Trim());
    parsedLine.Add(line.Substring(1,5).Trim());
    # Store parsed line in the result
    result.Add(parsedLine);

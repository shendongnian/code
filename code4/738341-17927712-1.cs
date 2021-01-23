    var nonEmptyLines =
      from line in File.ReadAllLines(path)
      where !String.IsNullOrEmpty(line.Trim())
      select line;
    if (nonEmptyLines.Any())
    {
      var lastLine = nonEmptyLines.Last();
      if (lastLine.StartsWith("9")) // or char.IsDigit(lastLine.First()) for 'any number'
      {
        // Your logic here
      }
    }

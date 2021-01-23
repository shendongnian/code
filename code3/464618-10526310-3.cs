    public static IEnumerable<string> GetUsings()
    {
        // Gets the file name of the caller
        var fileName = new StackTrace(true).GetFrame(1).GetFileName();
        // Get the "using" lines and extract and full namespace
        return File.ReadAllLines(fileName)
                   .Select(line => Regex.Match(line, "^\\s*using ([^; ]*)"))
                   .Where(match => match.Success)
                   .Select(match => match.Groups[1].Value);
    }

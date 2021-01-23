    var buffer = new List<string>();
    foreach (var line in File.EnumerateLines(pathToFile))
    {
        if (String.IsNullOrWhitespace(line))
        {
            ProcessSection(outputFile, buffer);
            buffer.Clear(); // or create a new one
        }
        else
        {
            buffer.Add(line);
        }
    }
    static void ProcessSection(StreamWriter outputFile, List<string> buffer)
    {
        var contents = buffer.Take(3)
            .Select(line => "\"" + line.Substring(line.IndexOf(": ") + 2) + "\"");
        outputFile.WriteLine(String.Join(",", contents));
    }

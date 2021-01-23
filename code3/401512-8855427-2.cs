    var buffer = new List<string>();
    foreach (var line in File.ReadLines(pathToFile))
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
        if (buffer.Count == 0) return;
        var contents = buffer.Take(3)
            .Select(line => String.Format("\"{0}\"", line.Substring(line.IndexOf(": ") + 2)));
        outputFile.WriteLine(String.Join(",", contents));
    }

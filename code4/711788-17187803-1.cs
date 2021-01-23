    using (var reader = new StreamReader(file_path))
    {
        foreach(string url in ReadLineFromFile(reader))
        {
            ...
        }
    }
    ...
    private static IEnumerable<string> ReadLineFromFile(TextReader fileReader)
    {
        while ((var currentLine = fileReader.ReadLine()) != null)
        {
            yield return currentLine;
        }
    }

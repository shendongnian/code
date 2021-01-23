    void DeleteLines()
    {
        var filePath = @"path/to/file.txt";
        string[] lines = File.ReadAllLines(filePath);
        File.WriteAllLines(filePath, lines.Where(KeepLine));
    }   
    bool KeepLine(string line)
    {
        // Decide whether to keep this line. The line below for example
        // Keeps all lines except the ones containing the word "Hey".
        return !line.Contains("Hey");
    }

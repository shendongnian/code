    private static void ReplaceLineInFile(string path, int lineNumber, string newLine)
    {
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            lines[lineNumber] = newLine;
            File.WriteAllLines(path, lines);
        }
    }

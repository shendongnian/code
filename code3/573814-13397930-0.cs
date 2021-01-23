    public static IEnumerable<String> GetDistinctLines(IEnumerable<String> lines)
    {
        string currentLine = null;
        foreach (var line in lines)
        {
            if (line != currentLine)
            {
                currentLine = line;
                yield return currentLine;
            }
        }
    }

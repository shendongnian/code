    private static IDictionary<string, int> ParseNameFile(string filename)
    {
        return File.ReadAllLines(filename)
            .OrderBy(n => n)
            .GroupBy(n => n)
            .ToDictionary(g => g.Key, g => g.Count);
    }

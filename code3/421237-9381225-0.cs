    GetLines(inputPath).FirstOrDefault(p=>p.Split(",")[0]=="SearchText")
    private static IEnumerable<string> GetLines(string inputFile)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(),inputFile);
        return File.ReadLines(filePath);
    }

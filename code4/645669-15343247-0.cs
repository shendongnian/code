    public static void WriteLines(string path, IEnumerable<string> lines)
    {
        using (var stream = File.CreateText(path))
        {
            foreach (var line in lines)
                stream.WriteLine(line);
        }
    }

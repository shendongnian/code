    public static void WriteAllLines(
        string path, IEnumerable<string> lines, string separator)
    {
        using (var writer = new StreamWriter(path))
        {
            foreach (var line in lines)
            {
                writer.Write(line);
                writer.Write(separator);
            }
        }
    }

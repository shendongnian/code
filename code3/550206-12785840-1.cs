    public void MergeFiles(string outputPath, string prefix, string suffix,
                           IEnumerable<string> files)
    {
        File.WriteAllText(outputPath, prefix);
        var lines = files.SelectMany(file => File.ReadLines(file).Skip(1));
        File.AppendAllLines(outputPath, lines);
        File.AppendAllText(outputPath, suffix);
    }

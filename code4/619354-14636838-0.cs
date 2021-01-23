    public void InsertLineBefore(string file, string lineToFind, string lineToInsert)
    {
        List<string> lines = File.ReadLines(file).ToList();
        int index = lines.IndexOf(lineToFind);
        // TODO: Validation (if index is -1, we couldn't find it)
        lines.Insert(index, lineToInsert);
        File.WriteAllLines(file, lines);
    }
    public void InsertLineAfter(string file, string lineToFind, string lineToInsert)
    {
        List<string> lines = File.ReadLines(file).ToList();
        int index = lines.IndexOf(lineToFind);
        // TODO: Validation (if index is -1, we couldn't find it)
        lines.Insert(index + 1, lineToInsert);
        File.WriteAllLines(file, lines);
    }

    string stringContains = string.Empty;
    var lines = File.ReadLines(Path);
    foreach (var line in lines)
    {
        if(line.Contains("<Root>"))
        {
            stringContains = line.Replace("<Root>", "<Root>" + newelement.OuterXml);
        }
    }
    File.WriteAllLines(Path, lines);

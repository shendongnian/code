    List<string> SearchFiles(string pattern)
    {
        var result = new List<string>();
        foreach (string drive in Directory.GetLogicalDrives())
        {
            var files = Directory.GetFiles(drive, pattern, SearchOption.AllDirectories);
            result.AddRange(files);
        }
        return result;
    }

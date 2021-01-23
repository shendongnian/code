    private void OpenLatestFileInLocal()
    {
        var latestFile = Directory
            .EnumerateFiles(localDir, "*.txt", SearchOption.AllDirectories)
            .Select(path => new { Path = path, Date = DateTime.ParseExact(
                path, "yyyyMMdd_HH", CultureInfo.InvariantCulture) })
            .OrderByDescending(df => df.Date)
            .Select(df => df.Path)
            .FirstOrDefault();
    
        if (latestFile != null)
        {
            OpenTxtFile(latestFile);
        }
    }
 

    var minTime = DateTime.MinValue;
    string theFile = null;
    foreach (var entry in Directory.GetFiles(dirName))
    {
        if (File.GetCreationTimeUtc(entry) > minTime)
        {
            minTime = File.GetCreationTimeUtc(entry);
            theFile = entry;
        }
    }

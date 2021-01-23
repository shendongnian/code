    var entries = Directory.EnumerateFileSystemEntries(@"D:\samples");
    foreach (var entry in entries)
    {
        if(File.Exists(entry))
        {
            //file
        }
        else
        {
            //directory
        }
    }

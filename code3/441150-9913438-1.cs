    var entries = Directory.EnumerateFileSystemEntries(rootDirectory);
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

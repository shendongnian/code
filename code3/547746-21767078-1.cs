    using System.IO.Compression;
    
    Stream data = new MemoryStream();       //The original data
    Stream otherData = new MemoryStream();  //The other stream being requested to add to.
    ZipArchive archive = new ZipArchive(data);
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        if(entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
             otherData = entry.Open(); // .Open will return a stream
        }
    }

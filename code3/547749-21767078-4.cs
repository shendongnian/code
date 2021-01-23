    using System.IO.Compression;
    
    Stream data = new MemoryStream(); // The original data
    Stream unzippedEntryStream; // Unzipped data from a file in the archive
    ZipArchive archive = new ZipArchive(data);
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        if(entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
             unzippedEntryStream = entry.Open(); // .Open will return a stream
             // Process entry data here
        }
    }

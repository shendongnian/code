    using (ArchiveFile archiveFile = new ArchiveFile(@"Archive.ARJ"))
    {
        foreach (Entry entry in archiveFile.Entries)
        {
            Console.WriteLine(entry.FileName);
    
            // extract to file
            entry.Extract(entry.FileName);
    
            // extract to stream
            MemoryStream memoryStream = new MemoryStream();
            entry.Extract(memoryStream);
        }
    }

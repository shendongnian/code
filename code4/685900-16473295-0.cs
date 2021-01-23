    ZipArchive archive = new ZipArchive(myStream)
    ZipArchiveEntry entry = archive.GetEntry("ExistingFile.txt");
    using (StreamWriter writer = new StreamWriter(entry.Open()))
    {
        writer.BaseStream.Seek(0, SeekOrigin.End);
        writer.WriteLine("append line to file");
    }
    entry.LastWriteTime = DateTimeOffset.UtcNow.LocalDateTime;

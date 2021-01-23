    using (var strm = File.OpenRead(zipPath))
    using (ZipArchive a = new ZipArchive(strm))
    {
        a.Entries.Where(o => o.Name == string.Empty && !Directory.Exists(Path.Combine(basePath, o.FullName))).ToList().ForEach(o => Directory.CreateDirectory(o.FullName));
        a.Entries.Where(o => o.Name != string.Empty).ToList().ForEach(e => e.ExtractToFile(Path.Combine(basePath, e.FullName), true));
    }

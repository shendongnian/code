    private void MergeDirectories(string Path1, string Path2)
    {
        string workspace = Environment.CurrentDirectory;
        string dir1 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        string dir2 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(dir1);
        Directory.CreateDirectory(dir2);
        Path1 = Path.GetFullPath(Path1);
        Path2 = Path.GetFullPath(Path2);
        using (ZipFile zip = ZipFile.Read(Path1))
        {
            zip.ExtractAll(dir1); //this line throws the error
        }
        using (ZipFile zip = ZipFile.Read(Path2))
        {
            zip.ExtractAll(dir1); //this line throws the error
        }
        string merged = Path.GetTempFileName();
        using (ZipFile z = new ZipFile())
        {
            z.AddDirectory(dir1);
            z.AddDirectory(dir2);
            z.Save(merged);
        }
        string newPath = Path.Combine(Environment.CurrentDirectory, "myarchive.zip");
        File.Move(merged, newPath);
    }

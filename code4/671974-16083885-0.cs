    private static Stream CreateFile(string path, bool append, bool checkHost)
    {
        FileMode mode = append ? FileMode.Append : FileMode.Create;
        return new FileStream(path, mode, FileAccess.Write, FileShare.Read, 4096, FileOptions.SequentialScan, Path.GetFileName(path), false, false, checkHost);
    }

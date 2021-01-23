    DirectoryInfo root = new DirectoryInfo(@"C:\");
    Func<FileSystemInfo, Boolean> predicate = dir =>
        (dir.Attributes & FileAttributes.System) != FileAttributes.System &&
        (dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden;
    IEnumerable<FileSystemInfo> directories = root.GetDirectories().Where(predicate);
    foreach (DirectoryInfo directory in directories) {
        try {
            Trace.WriteLine(directory.Name);
            DirectoryInfo[] subdirectories = directory.GetDirectories();
        }
        catch (System.UnauthorizedAccessException) {
            Trace.WriteLine("Insufficient access rights.");
        }
    }
    Trace.WriteLine("End of application.");

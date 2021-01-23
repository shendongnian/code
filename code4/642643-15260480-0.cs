    var directory = new DirectoryInfo(tagetDir);
    if (directory.Exists)
    {
        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(tagetDir, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
    }

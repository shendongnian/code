    try
    {
        subSubDirs = subDir.GetDirectories();
    }
    catch (System.UnauthorizedAccessException)
    {
        subSubDirs = new DirectoryInfo[0];
    }

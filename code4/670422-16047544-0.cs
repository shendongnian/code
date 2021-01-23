    string[] FoldersToLookAt = { @"e:\",
                                 @"e:\Kodak Images\",    // do you really need these,
                                 @"e:\images\",          // since you're already
                                 @"e:\AFSImageMerge\" }; // going through e:\ ?
    DateTime BeginningDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    foreach (string FolderPath in FoldersToLookAt)
    {
        DirectoryInfo FilesToLookThrough = new DirectoryInfo(FolderPath);
        foreach (FileInfo MyFile in FilesToLookThrough.EnumerateFiles("*.dat",
                                                        SearchOption.AllDirectories))
        {
            if (MyFile.LastAccessTime >= BeginningDate)
            {
                Console.WriteLine(MyFile.FullName);
            }
        }
    }

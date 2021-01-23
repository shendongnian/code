    TimeSpan BeginningTime = DateTime.Now.TimeOfDay;
    DateTime BeginningDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    DateTime EndingDate = DateTime.Now;
    string[] FoldersToLookAt = { @"e:\", @"e:\Kodak Images\", @"e:\images\", @"e:\AFSImageMerge\" };
    foreach (string FolderPath in FoldersToLookAt)
    {
        FilesToLookThrough = new DirectoryInfo(FolderPath);
        if (FilesToLookThrough.Exists)
        {
            foreach (var MyFile in FilesToLookThrough.EnumerateFiles("*.dat", SearchOption.AllDirectories))
            {
                if (MyFile.LastAccessTime >= BeginningDate)
                {
                    Console.WriteLine(MyFile.FullName);
                }
            }
        }
    }

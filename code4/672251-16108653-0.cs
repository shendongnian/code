    private void AddAllFilesOfAllSubdirsWithFilterToList(ref List<FileInfo> filesList, string dirPath, DateTime startDateUtc, DateTime? optionalEndDateUtc = null, List<string> blockedDirs = null)
    {
        // Input validation
        if (String.IsNullOrEmpty(dirPath))
        {
            throw new ArgumentException("Cannot search and empty path");
        }
        DirectoryInfo currentDir = new DirectoryInfo(dirPath);
        if (!currentDir.Exists)
        {
            throw new DirectoryNotFoundException(dirPath + " does not exist");
        }
        if (filesList == null)
        {
            filesList = new List<FileInfo>();
        }
        // Set endDate; add an hour to be safe
        DateTime endDateUtc = optionalEndDateUtc ?? DateTime.UtcNow.AddHours(1);
        // The current folder's LastWriteTime DOES update every time a child FILE is written to,
        // so if the current folder does not pass the date filter, we already know that no files within will pass, either
        if (currentDir.LastWriteTimeUtc >= startDateUtc && currentDir.LastWriteTimeUtc <= endDateUtc)
        {
            foreach (string filePath in Directory.GetFiles(dirPath, "*.*", SearchOption.TopDirectoryOnly))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.LastWriteTimeUtc > _sinceDate)
                {
                    filesList.Add(fileInfo);
                }
            }
        }
        // Unfortunately, the current folder's LastWriteTime does NOT update every time a child FOLDER is written to,
        // so we have to search ALL subdirectories regardless of the current folder's LastWriteTime
        foreach (string subDirPath in Directory.GetDirectories(dirPath))
        {
            if (blockedDirs == null || !blockedDirs.Any(p => subDirPath.ToLower().Contains(p)))
            {
                AddAllFilesOfAllSubdirsWithFilterToList(ref filesList, subDirPath, startDateUtc, optionalEndDateUtc, blockedDirs);
            }
        }
    }

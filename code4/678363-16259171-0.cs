    folderWatcher.Renamed += FolderWatcherOnRenamed;
    private static void FolderWatcherOnRenamed(object sender, RenamedEventArgs e)
    {
        var attr = File.GetAttributes(e.FullPath);
        if (attr == FileAttributes.Directory && e.OldName == "New Folder")
        {
            StartMonitoringDir(e.FullPath)
        }
    }

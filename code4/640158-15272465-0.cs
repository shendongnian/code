    private void FileSystemWatcherCreated(object sender, FileSystemEventArgs e)
    {
        long sizeOld = GetDirectorySize(new DirectoryInfo(e.FullPath));
        
        Thread.Sleep(100000);
        
        long sizeNew = GetDirectorySize(new DirectoryInfo(e.FullPath));
        
        if (sizeOld == sizeNew)
        {
        	// Copying finished.
        }
    }

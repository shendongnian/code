    // Add event handlers.
    fileSystemWatcher1.Created += new FileSystemEventHandler(OnChanged);
    // Enable the event to be raised
    fileSystemWatcher1.EnableRaisingEvents = true;
    // In the event handler check the change type
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify what is done when a file is changed, created, or deleted.
       Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
    }

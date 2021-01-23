    FileSystemWatcher fileWatcher = new FileSystemWatcher(@"C:\Documents and ettings\Develop\Desktop\test\");
    public void Initialize() //initialization or Constructor
    {
        fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
        fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
        fileWatcher.EnableRaisingEvents = true;
    }
    
    // Define the event handlers. 
    private void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify what is done when a file is changed, created, or deleted.
        MessageBox.Show("File: " + e.FullPath + " " + e.ChangeType);
    }

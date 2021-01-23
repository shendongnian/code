    protected override void OnStart(string[] args)
    {
    FileSystemWatcher Watcher = new FileSystemWatcher("PATH HERE");
    Watcher.EnableRaisingEvents = true;
    Watcher.Changed += new FileSystemEventHandler(Watcher_Changed);
    } 
    
    // This event is raised when a file is changed
    private void Watcher_Changed(object sender, FileSystemEventArgs e)
    {
    // your code here
    }

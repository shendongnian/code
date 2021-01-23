	public void init() {
		FileSystemWatcher watcher = new FileSystemWatcher();
		watcher.Path = "path/to/file";
		watcher.NotifyFilter = NotifyFilters.LastAccess
				| NotifyFilters.LastWrite | NotifyFilters.FileName
				| NotifyFilters.DirectoryName;
		// Only watch text files.
		watcher.Filter = "*.txt";
		// Add event handlers.
		watcher.Changed += new FileSystemEventHandler(OnChanged);
		watcher.Created += new FileSystemEventHandler(OnChanged);
		watcher.Deleted += new FileSystemEventHandler(OnChanged);
		watcher.Renamed += new RenamedEventHandler(OnRenamed);
		// Begin watching.
		watcher.EnableRaisingEvents = true;
	}
	// Define the event handlers.
	private static void OnChanged(object source, FileSystemEventArgs e) {
		// Specify what is done when a file is changed, created, or deleted.		
	}
	private static void OnRenamed(object source, RenamedEventArgs e) {
		// Specify what is done when a file is renamed.		
	}

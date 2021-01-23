    public class MyWatcher
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private Timer timer;
        private List<FileSystemEventArgs> events = new List<FileSystemEventArgs>();
        public delegate void FileSystemMultipleEventHandler(object sender, List<FileSystemEventArgs> events);
        public FileSystemMultipleEventHandler OnMultipleFilesCreate { get; set; }
        public MyWatcher(string path)
        {
            this.watcher.Path = path;
            this.watcher.Created += FileCreated;
        }
        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            if (this.timer != null)
                timer.Dispose();
            this.events.Add(e);
            this.timer = new Timer(MultipleFilesCreated, e, 0, 200);
        }
        private void MultipleFilesCreated(object stat)
        {
            if (this.OnMultipleFilesCreate != null)
                OnMultipleFilesCreate(this, this.events);
        }
    }

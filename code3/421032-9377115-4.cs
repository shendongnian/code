    public class MyWatcher
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private System.Timers.Timer timer;
        private List<FileSystemEventArgs> events = new List<FileSystemEventArgs>();
        public delegate void FileSystemMultipleEventHandler(object sender, List<FileSystemEventArgs> events);
        public FileSystemMultipleEventHandler OnMultipleFilesCreated { get; set; }
        public MyWatcher(string path, NotifyFilters notifyFilters, string filter)
        {
            this.watcher.Path = path;
            this.watcher.Created += FileCreated;
            watcher.Filter = filter;
            watcher.EnableRaisingEvents = true;
        }
        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.events.Add(e);
                this.timer.Start();
            }
            else
            {
                this.events.Add(e);
                this.timer = new Timer(200);
                this.timer.Elapsed += MultipleFilesCreated;
                this.timer.Start();
            }
        }
        private void MultipleFilesCreated(object stat, ElapsedEventArgs args)
        {
            if (OnMultipleFilesCreated != null)
                OnMultipleFilesCreated(this, events);
            this.timer.Dispose();
        }
    }

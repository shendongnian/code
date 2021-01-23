    public class MyWatcher
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private System.Timers.Timer timer;
        private object listSync = new object();
        private List<FileSystemEventArgs> events = new List<FileSystemEventArgs>();
        public delegate void FileSystemMultipleEventHandler(object sender, FileSystemEventArgs[] events);
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
                lock (this.listSync) this.events.Add(e);
                this.timer.Start();
            }
            else
            {
                lock (this.listSync) this.events.Add(e);
                this.timer = new Timer(200);
                this.timer.Elapsed += MultipleFilesCreated;
                this.timer.Start();
            }
        }
        private void MultipleFilesCreated(object stat, ElapsedEventArgs args)
        {
            if (OnMultipleFilesCreated != null)
            {
                FileSystemEventArgs[] result;
                lock (this.listSync)
                {
                    // make a copy
                    result = events.ToArray();
                    this.events = new List<FileSystemEventArgs>();
                }
                OnMultipleFilesCreated(this, result);
            }
            this.timer.Stop();
        }
    }

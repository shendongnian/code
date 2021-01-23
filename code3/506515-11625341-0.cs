    class MyViewModel
    {
        private readonly SynchronizationContext _syncContext;
        public MyViewModel()
        {
            // we assume this ctor is called from the UI thread!
            _syncContext = SynchronizationContext.Current;
        }
        // ...
        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
             _syncContext.Post(o => DGAddRow(crp.Protocol, ft), null);
        }
    }

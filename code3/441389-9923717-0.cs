    public class Watcher
    {
        private ManualResetEvent resetEvent = new ManualResetEvent(false);
        public ManualResetEvent ResetEvent { get { return resetEvent; }
        void Created()
        {
            FileSystemWatcher Watcher2 = new FileSystemWatcher();
            Watcher2.Path = txtBxDirToWatch.Text;
            Watcher2.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.DirectoryName;
            //watch all files in the path 
            Watcher2.Filter = "*.*";
            //dont watch sub dir as default
            Watcher2.IncludeSubdirectories = false;
            if (chkBxIncSub.Checked)
            {
                Watcher2.IncludeSubdirectories = true;
            }
            Watcher2.Created += new FileSystemEventHandler(OnCreated);
            Watcher2.EnableRaisingEvents = true;
            resetEvent.WaitOne();
        }

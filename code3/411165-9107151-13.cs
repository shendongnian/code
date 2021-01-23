        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void btn_start_Click(object sender, EventArgs e)
        {
            string FolderPath = this.txtfolder.Text;
            string Filter = this.txtfilter.Text;
            if(!Directory.Exists(FolderPath))
            {
                Console.WriteLine("Not a valid directory"); //checks directory is valid
                return;
            }
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = FolderPath;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch filter files.
            watcher.Filter = Filter;
            watcher.IncludeSubdirectories = true; //monitor subdirectories?
            watcher.EnableRaisingEvents = true; //allows for changed events to be fired.
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
        }
        //Delegate to get back to UI thread since OnChanged fires on non-UI thread.
        private delegate void updateListbox(string context);
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            this.Invoke(new updateListbox(UpdateListbox), "File: " + e.Name);
            this.Invoke(new updateListbox(UpdateListbox), ">>Action: " + e.ChangeType);
            this.Invoke(new updateListbox(UpdateListbox), ">>Path: " + e.FullPath);
        }
        public void UpdateListbox(string context)
        {
            lsttracker.Items.Add(context);
        }

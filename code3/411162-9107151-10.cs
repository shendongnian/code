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
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
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
            this.Invoke(new updateListbox(UpdateListbox), "Changed File: " + e.Name);
            this.Invoke(new updateListbox(UpdateListbox), "--Change Type: " + e.ChangeType);
            this.Invoke(new updateListbox(UpdateListbox), "--Full Path: " + e.FullPath);
        }
        public void UpdateListbox(string context)
        {
            lsttracker.Items.Add(context);
        }

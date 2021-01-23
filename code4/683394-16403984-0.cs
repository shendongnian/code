     private void Form1_Load(object sender, EventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Application.StartupPath;
            watcher.Filter = Path.GetFileName(Application.StartupPath+ @"\RBsTurn.txt");
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            watcher.EnableRaisingEvents = true;
        }
        void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Clipboard.Clear();
            });
            th.IsBackground = true;
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
         }

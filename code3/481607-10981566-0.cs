    public Service1()
            {
                InitializeComponent();
            }
    
            Thread thread;
    
            protected override void OnStart(string[] args)
            {
                try
                {
                    thread = new Thread(delegate()
                    {
                        string path = @"D:\levani\FolderListenerTest\ListenedFolder";
                        FileSystemWatcher listener; listener = new FileSystemWatcher(path);
                        listener.Created += new FileSystemEventHandler(listener_Created);
                        listener.EnableRaisingEvents = true;
                    });
                    thread.Start();
                }
                catch (Exception ex)
                {
                    File.WriteAllText(@"D:\levani\bussite.txt", "thread: " + ex.ToString());
                }
            }
    
            public void listener_Created(object sender, FileSystemEventArgs e)
            {
                try
                {
                    File.Copy(e.FullPath, @"D:\levani\FolderListenerTest\CopiedFilesFolder\F" + e.Name);
                }
                catch (Exception ex)
                {
                    File.WriteAllText(@"D:\levani\bussite.txt", "File copy ex: " + ex.ToString());
                }
            }
    
            protected override void OnStop()
            {
                thread.Abort();
            }

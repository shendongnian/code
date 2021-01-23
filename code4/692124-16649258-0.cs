    public partial class Form1 : Form
        {
            System.Timers.Timer tim = new System.Timers.Timer();
            int totalSeconds = 0;
    
            public Form1()
            {
                InitializeComponent();
    
                tim.Interval = 1000; // 1 sec
                tim.Elapsed += new System.Timers.ElapsedEventHandler(tim_Elapsed);
            }
    
            void tim_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                // .....
                totalSeconds++;
    
                if (totalSeconds == 2) // 2 sec of wait
                {
                    tim.Stop();
                    Application.Exit();
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                FileSystemWatcher fsw = new FileSystemWatcher("D:\\");
    
                fsw.IncludeSubdirectories = true;
                fsw.Filter = "file.exe";
    
                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    
                fsw.Changed += new FileSystemEventHandler(OnChanged);
    
                fsw.Created += new FileSystemEventHandler(OnCreated);
    
                fsw.Deleted += new FileSystemEventHandler(OnDeleted);
    
                fsw.Renamed += new RenamedEventHandler(OnRenamed);           
    
                fsw.EnableRaisingEvents = true;
            }
    
          
    
            private  void OnChanged(object source, FileSystemEventArgs e)
            {
                //  Show that a file has been created, changed, or deleted.
                WatcherChangeTypes wct = e.ChangeType;
                Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString());
                MessageBox.Show("OnChanged File {0} {1}" + e.FullPath + wct.ToString());
    
                tim.Start();
            }
    
            private void OnCreated(object source, FileSystemEventArgs e)
            {
                //  Show that a file has been created, changed, or deleted.
                WatcherChangeTypes wct = e.ChangeType;
                Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString());
                MessageBox.Show("OnCreated File {0} {1}" + e.FullPath + wct.ToString());
    
                tim.Start();
            }
    
            private void OnDeleted(object source, FileSystemEventArgs e)
            {
                //  Show that a file has been created, changed, or deleted.
                WatcherChangeTypes wct = e.ChangeType;
                Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString());
                MessageBox.Show("OnDeleted File {0} {1}" + e.FullPath + wct.ToString());
    
                tim.Start();
            }
    
            //  This method is called when a file is renamed. 
            private  void OnRenamed(object source, RenamedEventArgs e)
            {
                //  Show that a file has been renamed.
                WatcherChangeTypes wct = e.ChangeType;
                Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString());
                MessageBox.Show("OnRenamed File {0} {2} to {1}" + e.OldFullPath + e.FullPath + wct.ToString());
    
                tim.Start(); // start timer as you get file.exe found....
            }
        }

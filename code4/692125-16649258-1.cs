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
                //  Show that a file has been changed
                WatcherChangeTypes wct = e.ChangeType;                
                MessageBox.Show("OnChanged File " + e.FullPath + wct.ToString());    
                tim.Start();// start timer as you get file.exe found....
            }
    
            private void OnCreated(object source, FileSystemEventArgs e)
            {
                //  Show that a file has been created
                WatcherChangeTypes wct = e.ChangeType;                
                MessageBox.Show("OnCreated File " + e.FullPath + wct.ToString());    
                tim.Start();// start timer as you get file.exe found....
            }
    
            private void OnDeleted(object source, FileSystemEventArgs e)
            {
                //  Show that a file has been deleted.
                WatcherChangeTypes wct = e.ChangeType;               
                MessageBox.Show("OnDeleted File " + e.FullPath + wct.ToString());    
                tim.Start();// start timer as you get file.exe found....
            }
    
            //  This method is called when a file is renamed. 
            private  void OnRenamed(object source, RenamedEventArgs e)
            {
                //  Show that a file has been renamed.
                WatcherChangeTypes wct = e.ChangeType;               
                MessageBox.Show("OnRenamed File " + e.OldFullPath + e.FullPath + wct.ToString());    
                tim.Start(); // start timer as you get file.exe found....
            }
        }

    private Boolean TimeToCheck=false;
    public static void Run()
    {   Timer timer=new Timer(2000); //2 seconds
        FileSystemWatcher fileWatch=new FileSystemWatcher();
        fileWatch.Path="DirToWatch";
        fileWatch.Filter="fileToWatch";
        fileWatch.Changed += new FileSystemEventHandler(OnChanged);
        fileWatch.Created += new FileSystemEventHandler(OnChanged);
        fileWatch.Deleted += new FileSystemEventHandler(OnChanged);
        //If you want rename, you could use the rename event as well  fileWatch.Renamed += new RenamedEventHandler(OnRenamed);
        timer.Elapsed += new ElapsedEventHandler(timer_done);
        watcher.EnableRaisingEvents = true;
        timer.Enabled = true; // Enable it
    }
    
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        if(TimeToCheck)
        {
            TimeToCheck=false;
            timer.Enabled = false; // Enable it
            //move the files
            timer.Enabled = true; // Enable it
        }
    
    }
    private static void OnRenamed(object source, RenamedEventArgs e)
    {
        if(TimeToCheck)
        {
            TimeToCheck=false;
            timer.Enabled = false; // Enable it
            //move the files
            timer.Enabled = true; // Enable it
        }
    }
    private static void timer_done(object sender, ElapsedEventArgs e)
    {
        TimeToCheck=true;
    }

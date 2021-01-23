    static void Main(string[] args)
    {
        Timer.Interval = 5000; // 5 seconds - change to whatever is appropriate
        Timer.AutoReset = false;
        Timer.Elapsed += TimeoutDone;
        String path = @"D:\Music";
        FileSystemWatcher mWatcher = new FileSystemWatcher();
        mWatcher.Path = path;
        mWatcher.NotifyFilter = NotifyFilters.LastAccess;
        mWatcher.NotifyFilter = mWatcher.NotifyFilter | NotifyFilters.LastWrite;
        mWatcher.NotifyFilter = mWatcher.NotifyFilter | NotifyFilters.DirectoryName;
        mWatcher.IncludeSubdirectories = true;
        mWatcher.Created += new FileSystemEventHandler(mLastChange);
        mWatcher.Changed += new FileSystemEventHandler(mLastChange);
        mWatcher.EnableRaisingEvents = true;
        Console.WriteLine("Watching path: " + path);
        Timer.Start();
        String exit;
        while (true)
        {
            exit = Console.ReadLine();
            if (exit == "exit")
                break;
        }
    }
    private static Timer Timer = new Timer();
    private static void TimeoutDone(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Timer elapsed!");
    }
    private static void mLastChange(Object sender, FileSystemEventArgs e)
    {
        Console.WriteLine(e.ChangeType + " " + e.FullPath);
        if (Timer != null)
        {
            Timer.Stop();
            Timer.Start();
        }
    }

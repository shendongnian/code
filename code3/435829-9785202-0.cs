    static Form InvokerForm;
    public static void Main()
    {
        InvokerForm = new Form();
        var dummy = InvokerForm.Handle; // form handle creation is lazy; force it to happen
        var watcher = new FileSystemWatcher();
        watcher.SynchronizingObject = InvokerForm;
        watcher.Path = @"C:\Input\";
        watcher.Filter = "*.csv";
        watcher.Created += new FileSystemEventHandler(ProcessFile);
        watcher.EnableRaisingEvents = true;
        Application.Run();
    }

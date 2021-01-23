    static void Main(string[] args)
    {
        //Creating test file. Can be removed.
        File.WriteAllText("test.txt", "test");
        // object that will watch changes for your file on file system
        var watcher = new FileSystemWatcher();
        watcher.Renamed += watcher_Renamed;
    }
    private static void watcher_Renamed(object sender, RenamedEventArgs e)
    {
        // This event is fired when file is renamed. Do your own stuff here.
        Console.WriteLine(e.OldName + " => " + e.Name);
    }

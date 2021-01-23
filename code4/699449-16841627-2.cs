    private FileSystemWatcher fsw;
    public MainWindow()
    {
        InitializeComponent();
        fsw = new FileSystemWatcher
        {
            Path = @"C:\Users\Path\To\File",
            Filter = "Test_1234.prn",
            NotifyFilter = NotifyFilters.LastWrite
        };
        fsw.Changed += (o, e) =>
            {
                var lastLine = File.ReadAllLines(e.FullPath).Last();
                Dispatcher.BeginInvoke((Action<string>)HandleChanges, lastLine);
            };
        fsw.EnableRaisingEvents = true;
    }
    private void HandleChanges(string lastLine)
    {
        // update UI here
    }

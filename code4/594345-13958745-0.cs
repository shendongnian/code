    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        base.OnStartup(sender, e);
        RegisterHotKeys(Application.MainWindow);
    }
    private void RegisterHotKeys(Window mainWindow)
    {
        var hotKey = new HotKey(ModifierKeys.Control | ModifierKeys.Shift, Key.V, mainWindow);
        hotKey.HotKeyPressed += OnHotKeyPressed;
    }
    private void OnHotKeyPressed(HotKey hotKey)
    {
        // Do whatever you want to do here
    }

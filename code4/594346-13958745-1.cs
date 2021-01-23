    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        RegisterHotKeys();
    }
    private void RegisterHotKeys()
    {
        var hotKey = new HotKey(ModifierKeys.Control | ModifierKeys.Shift, Key.V, MainWindow);
        hotKey.HotKeyPressed += OnHotKeyPressed;
    }
    private void OnHotKeyPressed(HotKey hotKey)
    {
        // Do whatever you want to do here
    }

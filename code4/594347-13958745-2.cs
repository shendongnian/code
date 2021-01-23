    public partial class App
    {
        private HotKey _hotKey;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            RegisterHotKeys();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            UnregisterHotKeys();
        }
        private void RegisterHotKeys()
        {
            if (_hotKey != null) return;
            _hotKey = new HotKey(ModifierKeys.Control | ModifierKeys.Shift, Key.V, Current.MainWindow);
            _hotKey.HotKeyPressed += OnHotKeyPressed;
        }
        private void UnregisterHotKeys()
        {
            if (_hotKey == null) return;
            _hotKey.HotKeyPressed -= OnHotKeyPressed;
            _hotKey.Dispose();
        }
        private void OnHotKeyPressed(HotKey hotKey)
        {
            // Do whatever you want to do here
        }
    }

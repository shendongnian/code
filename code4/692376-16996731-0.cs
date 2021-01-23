    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += (s, args) =>
        {
            if ((args.EventType == CoreAcceleratorKeyEventType.SystemKeyDown 
                || args.EventType == CoreAcceleratorKeyEventType.KeyDown)
                && (args.VirtualKey == VirtualKey.Up))
            {
                MoveUp();
            }
            else if ((args.EventType == CoreAcceleratorKeyEventType.SystemKeyDown 
                || args.EventType == CoreAcceleratorKeyEventType.KeyDown)
                && (args.VirtualKey == VirtualKey.Down))
            {
                MoveDown();
            }
        };
    }
    private void MoveUp()
    {
        // this part is up to you
        throw new NotImplementedException();
    }
    private void MoveDown()
    {
        // this part is up to you
        throw new NotImplementedException();
    }

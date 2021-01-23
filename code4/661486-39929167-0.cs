    public MyPage()
    {
        Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += AcceleratorKeyActivated;
    }
    
    private void AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
    {
        if (args.EventType.ToString().Contains("Down"))
        {
            var ctrl = Window.Current.CoreWindow.GetKeyState(VirtualKey.Control);
            if (ctrl.HasFlag(CoreVirtualKeyStates.Down))
            {
                switch (args.VirtualKey)
                {
                    case VirtualKey.A:
                        Debug.WriteLine(args.VirtualKey);
                        Play_click(sender, new RoutedEventArgs());
                        break;
                }
            }
        }
    }

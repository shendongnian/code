    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        // Set the input focus to ensure that keyboard events are raised.
        this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
    }
    
    private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Control) isCtrlKeyPressed = false;
    }
    
    private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Control) isCtrlKeyPressed = true;
        else if (isCtrlKeyPressed)
        {
            switch (e.Key)
            {
                case VirtualKey.P: DemoMovie.Play(); break;
                case VirtualKey.A: DemoMovie.Pause(); break;
                case VirtualKey.S: DemoMovie.Stop(); break;
            }
        }
    }

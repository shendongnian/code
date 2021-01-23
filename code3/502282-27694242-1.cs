    private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
    
        var mouseDownEvent =
            new MouseButtonEventArgs(Mouse.PrimaryDevice,
                Environment.TickCount,
                MouseButton.Right)
            {
                RoutedEvent = Mouse.MouseUpEvent,
                Source = Win,
            };
    
    
        InputManager.Current.ProcessInput(mouseDownEvent);
    }

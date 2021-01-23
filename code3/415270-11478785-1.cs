    RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
    {
      RoutedEvent = Mouse.MouseDownEvent,
      Source = this,
    });
    

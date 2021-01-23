    InputManager.Current.ProcessInput(
        new KeyEventArgs(Keyboard.PrimaryDevice,
            Keyboard.PrimaryDevice.ActiveSource,
            0, Key.Tab)
        {
           RoutedEvent = Keyboard.KeyDownEvent
        }
    );

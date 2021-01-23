    //<summary>
    //Function to Perform a Keyboard KeyPress.
    //</summary>
    void PressKey(Key KeyboardKey)
    {
        KeyEventArgs args = new KeyEventArgs(Keyboard.PrimaryDevice,
        Keyboard.PrimaryDevice.ActiveSource, 0, Key.LeftAlt);
        args.RoutedEvent = Keyboard.KeyDownEvent;
        InputManager.Current.ProcessInput(args);
    }

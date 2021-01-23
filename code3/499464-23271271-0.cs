    /// <summary>
    /// Returns mouse click.
    /// </summary>
    /// <returns>mouseeEvent</returns>
    public static MouseButtonEventArgs MouseClickEvent()
    {
        MouseDevice md = InputManager.Current.PrimaryMouseDevice;
        MouseButtonEventArgs mouseEvent = new MouseButtonEventArgs(md, 0, MouseButton.Left);
        return mouseEvent;
    }

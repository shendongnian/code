    /// <summary>
    ///   Sends the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    public static void Send(Key key)
    {
      if (Keyboard.PrimaryDevice != null)
      {
        if (Keyboard.PrimaryDevice.ActiveSource != null)
        {
          var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key) 
          {
              RoutedEvent = Keyboard.KeyDownEvent
          };
          InputManager.Current.ProcessInput(e);
          // Note: Based on your requirements you may also need to fire events for:
          // RoutedEvent = Keyboard.PreviewKeyDownEvent
          // RoutedEvent = Keyboard.KeyUpEvent
          // RoutedEvent = Keyboard.PreviewKeyUpEvent
        }
      }
    }

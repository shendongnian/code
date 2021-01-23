    public static class SendKeys
    {
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null) {
                if (Keyboard.PrimaryDevice.ActiveSource != null) {
                    var e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key) { RoutedEvent = Keyboard.KeyDownEvent };
                    InputManager.Current.ProcessInput(e1);
                }
            }
        }
    }

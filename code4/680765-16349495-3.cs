    EventManager.RegisterClassHandler(typeof(UIElement), AccessKeyManager.AccessKeyPressedEvent, new AccessKeyPressedEventHandler(OnAccessKeyPressed));
    private void OnAccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
    {
        if (!e.Handled && e.Scope == null && (e.Target == null || e.Target == label))
        {
            // If Alt key is not pressed - handle the event
            if ((Keyboard.Modifiers & ModifierKeys.Alt) != ModifierKeys.Alt)
            {
                e.Target = null;
                e.Handled = true;
            }
        }
    }

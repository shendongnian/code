    private void onAcceleratorKey(object sender, AcceleratorKeyEventArgs e)
    {
        CoreVirtualKeyStates ctrl = Window.Current.CoreWindow.GetAsyncKeyState(VirtualKey.Control);
        if (ctrl == CoreVirtualKeyStates.Down)
        {
            switch (e.VirtualKey)
            {
                case VirtualKey.F:
                    // CTRL + F pressed.
                    break;
            }
        }
    }

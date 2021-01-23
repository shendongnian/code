    void MainPage_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        // Check for input device
        if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
        {
            var properties = e.GetCurrentPoint(this).Properties;
            if (properties.IsLeftButtonPressed)
            {
                // Left button pressed
            }
            else if (properties.IsRightButtonPressed)
            {
                // Right button pressed
            }
        }
    }

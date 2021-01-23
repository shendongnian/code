        private void textbox_input_LostFocus(object sender, RoutedEventArgs e)
        {
            textbox_input.IsReadOnly = false;
        }
        private void textbox_input_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(e.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Mouse)
                textbox_input.IsReadOnly = true;
            else
                textbox_input.IsReadOnly = false;
        }

        private void EntryFunc(object sender, RoutedEventArgs e) { ControlsEn(false); }
        private void ExitFunc(object sender, RoutedEventArgs e) { ControlsEn(true); }
        private void ControlsEn(bool V)
        {
            this.cmdConnect.IsEnabled = V; // disable button or group or whatever
            ...
        }
        private void cmdConnect_ThreadClick(object sender, RoutedEventArgs e)
        {
            // NOTE This function is NOT on the GUI thread, GUI elements cannot be accessed directly
            // SafeGuiWpf is a static class I created to handle this (see below)
            if (SafeGuiWpf.GetChecked(optSerial)==true)
            {
                ...
            }
        }

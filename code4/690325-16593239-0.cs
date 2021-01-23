    Microsoft.Win32.SystemEvents.PowerModeChanged += this.SystemEvents_PowerModeChanged;
    
        private void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
                {
                    
                }
        
            if (e.Mode == PowerModes.Resume)
                {
                    
                }
        }

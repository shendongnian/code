    SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
    void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
        if (e.Mode != PowerModes.Resume)
            serialPort.Close();
    }

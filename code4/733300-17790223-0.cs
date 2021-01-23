    public void SubscribeEvents()
    {
        SystemEvents.DisplaySettingsChanged += new
        EventHandler(SystemEvents_DisplaySettingsChanged);
    }
    
    public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
    {
       // Get the current resolution
       // Alter form size accordingly
    }

    int previous = -1;
    int current = -1;
    private bool CheckScreenChanged()
    {
    	bool changed = false;
        Screen curr = Screen.FromControl(this); // gets the current screen assuming the current context of this is a Form instance. Change to suit.
        for (int i = 0; i < Screen.AllScreens.Length; i++)
        {
            Screen item = Screen.AllScreens[i];
            if (curr.DeviceName == item.DeviceName)
            {
    			current = i;
            }
        }
    
        if (current != -1 && previous != -1 && current != previous) // form changed screen.
        {
    		changed = true;
        }
    
        previous = current;
        return changed;
    }
    
    private void ScreenChanged()
    {
    	// handle the current screen for the Form.
        label1.Text = "Screen " + current.ToString();
    }
    
    private void Form_Moved(object sender, System.EventArgs e)
    {
    	bool changed = CheckScreenChanged();
    	if (changed == true)
    	{
    		ScreenChanged();
    	}
    }
    
    private void ResolutionChanged()
    {
    	// handle the resize of the current screen that the form is rendered on
        label1.Text = "Res Changed";
    }
    
    public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
    {
    	CheckScreenChanged();
        Screen curr = Screen.AllScreens[current];
        Screen prev = Screen.AllScreens[previous];
    
        if (curr.Bounds != prev.Bounds) // resolution changed
        {
    		ResolutionChanged();
        }
    }
    
    public void SubscribeEvents()
    {
    	this.Move += Form_Moved;
        SystemEvents.DisplaySettingsChanged += new
        EventHandler(SystemEvents_DisplaySettingsChanged);
    }

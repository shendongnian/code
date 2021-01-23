    int? previous = null;
    int? current = null;
    private bool CheckScreenChanged()
    {
        bool changed = false;
        Screen curr = Screen.FromControl(this); // gets the current screen assuming the current context of this is a Form instance. Change to suit.
        for(int i = 0; i < Screen.AllScreens.Length; i++)
        {
            Screen item = Screen.AllScreens[i];
            if(curr == item)
            {
                current = i;
            }
        }
       
        if(current != null && previous != null && current != previous)
        {
            changed = true;
        }
        previous = current;
        
        return changed;
    }
    private void ScreenChanged()
    {
        // handle the current screen for the Form.
    }
    private void Form_Moved(object sender, System.EventArgs e)
    {
        bool changed = CheckScreenChanged();
        if(changed == true)
        {
            ScreenChanged();
        }
    }
    private void ResolutionChanged()
    {
         // handle the resize of the current screen that the form is rendered on
    }
    public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
    {
        CheckScreenChanged();
        Screen curr = Screen.AllScreens[current];
        Screen prev = Screen.AllScreens[previous];
        if(current.Bounds != previous.Bounds) // resolution changed
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

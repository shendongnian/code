    struct Resolution
    {
        public int Width;
        public int Height;
    }
            
    int previous = -1;
    int current = -1;
    
    private bool CheckScreenChanged()
    {
        bool changed = false;
        current = GetScreenIndex();
    
        if (current != -1 && previous != -1 && current != previous) // form changed screen.
        {
            changed = true;
        }
    
        previous = current;
        return changed;
    }
    
    private int GetScreenIndex()
    {
        int index = -1;
        Screen curr = Screen.FromControl(this); // gets the current screen assuming the current context of this is a Form instance. Change to suit.
        for (int i = 0; i < Screen.AllScreens.Length; i++)
        {
            Screen item = Screen.AllScreens[i];
            if (curr.DeviceName == item.DeviceName)
            {
                index = i;
            }
        }
        return index;
    }
    
    private Resolution GetCurrentResolution()
    {
        Screen screen = Screen.FromControl(this);
        Resolution res = new Resolution();
        res.Width = screen.Bounds.Width;
        res.Height = screen.Bounds.Height;
                
        return res;
    }
            
    private void SetResolutionLabel()
    {
        Resolution res = GetCurrentResolution();
        label2.Text = String.Format("Width: {0}, Height: {1}", res.Width, res.Height);
    }
    
    private void ScreenChanged()
    {
        label1.Text = "Screen " + current.ToString();
    }
    
    private void Form_Moved(object sender, System.EventArgs e)
    {
        bool changed = CheckScreenChanged();
        if (changed == true)
        {
            ScreenChanged();
            SetResolutionLabel();
        }
    }
    
    public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
    {
        SetResolutionLabel();
    }
    
    public void Initialize()
    {
        this.Move += Form_Moved;
        SystemEvents.DisplaySettingsChanged += new
        EventHandler(SystemEvents_DisplaySettingsChanged);
    
        previous = GetScreenIndex();
        current = GetScreenIndex();
        ScreenChanged();
        SetResolutionLabel();
    }

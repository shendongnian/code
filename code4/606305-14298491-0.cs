    // Member Variables
    ToolTip toolTip = new ToolTip();
    string toolTipText = "Your tool tip goes here.";
    Timer toolTipTimer = new Timer();
    public TimeSpan ToolTipDelay
    {
      get { return TimeSpan.FromMilliseconds(toolTipTimer.Interval); }
      set { toolTipTimer.Interval = (int)value.TotalMilliseconds; }
    }
    // Call this in your CustomControl constructor!
    void InitializeToolTipTimer()
    {
      this.ToolTipDelay = TimeSpan.FromSeconds(1);
      toolTipTimer.Tick += (sender, e) =>
      {
        toolTipTimer.Stop(); // Tick only once per MouseEnter
        toolTip.SetToolTip(this, toolTipText);
      };
    }
    void OnToolTipMouseEnter(object sender, EventArgs e)
    {
      toolTipTimer.Start(); // Start the ToolTip display Timer
    }
    void OnToolTipMouseLeave(object sender, EventArgs e)
    {
      toolTipTimer.Stop(); // Cancel any pending ToolTip display
      toolTip.RemoveAll();      
    }

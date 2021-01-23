    RadTab previous = FIRST_TAB;
    void RadTab_OnClick(object sender, EventArgs ea)
    {
        // this will be tab #N
        var tab = (RadTab)sender;
        
        // disregard the first tab
        if (tab.Index == 0 || previous.Index > tab.Index) return;
        // validate N-1
        radTabStrip.Tabs[tab.Index - 1].Validate();
    }
    void RadTab_OnLostFocus(object sender, EventArgs ea)
    {
         previous = (RadTab)sender;
    }

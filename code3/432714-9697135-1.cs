    delegate TabControl getTabDelegate(); 
    private TabControl getTab() 
    { 
        if (this.channelTabs.InvokeRequired) 
        { 
            getTabDelegate d = new getTabDelegate(getTab); 
            return this.Invoke(d); // Don't lose the return value from the invoked call
            //return null; 
        } 
        else 
        { 
            return channelTabs; 
        } 
    }

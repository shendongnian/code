    private TabControl getTab()
    {
        if (this.channelTabs.InvokeRequired)
        {
            getTabDelegate d = new getTabDelegate(getTab);
            return (TabControl)this.Invoke(d);
        }
        else
        {
            return channelTabs;
        }
    }

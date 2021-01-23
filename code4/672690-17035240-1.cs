    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        
        var state = SuspensionManager.SessionStateForFrame(this.Frame);
        if (state != null && state.ContainsKey("mruToken"))
        {
            object value = null;
            if (state.TryGetValue("mruToken", out value))
            {
               // the same code as LoadState to retrieve the image  
            }
        }
    }

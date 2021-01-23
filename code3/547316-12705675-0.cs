    delegate void ActionCallback();
    
    private void SetText()
    {
        this.SafeInvoke(() =>
    		{
    			if (spinCell1Cell2.IsDisposed) return;
    			if (!spinCell1Cell2.IsHandleCreated) return;
    			// Do stuff
    		});
    }
    
    private void SafeInvoke(ActionCallback action)
    {
    	if (this.InvokeRequired)
    		this.Invoke(action);
    	else
    		action();
    }

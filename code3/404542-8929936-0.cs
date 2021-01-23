    public event EventHandler LoginFailed;
    
    public void Login()
    {
    	if (fail)
    	{
    		if (this.LoginFailed != null)
    		{
    			this.LoginFailed(this, EventArgs.Empty);
    		}
    	}
    }

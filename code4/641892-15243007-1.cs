    public bool checkLamp(int iLamp)
    {
        Phone.ButtonIDConstants btn = new Phone.ButtonIDConstants();
        btn = Phone.ButtonIDConstants.BUTTON_1;
        btn += iLamp;
    	
    	AutoResetEvent waitHandle = new AutoResetEvent(false); 
    	
    	// Pass waitHandle as user state
        Phone.GetLampMode(btn, waitHandle);
    
        // Wait for event completion
        waitHandle.WaitOne();
    
        return true;
    }
    
    private void Phone_OnGetLampModeResponse(object sender, Phone.GetLampModeResponseArgs e)
    {
        var test = e.getLampModeList[0].getLampMode.ToString();
    
        // Event handler completed
    	// I guess there is some UserState property in the GetLampModeResponseArgs class
    	((AutoResetEvent)e.UserState).Set();
    }

    private AutoResetEvent waitHandle = new AutoResetEvent(false); 
    
    public bool checkLamp(int iLamp)
    {
        Phone.ButtonIDConstants btn = new Phone.ButtonIDConstants();
        btn = Phone.ButtonIDConstants.BUTTON_1;
        btn += iLamp;
        Phone.GetLampMode(btn, null);
    
    	// Wait for event completion
    	waitHandle.WaitOne();
    	
        return true;
    }
    
    private void Phone_OnGetLampModeResponse(object sender, Phone.GetLampModeResponseArgs e)
    {
        var test = e.getLampModeList[0].getLampMode.ToString();
    	
    	// Event handler completed
    	waitHandle.Set();
    }

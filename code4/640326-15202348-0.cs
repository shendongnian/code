    private void tabPasswords_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	if (e.Source is TabControl)
    	{
    		TabControl tab = (TabControl)e.Source;
    		switch (tab.SelectedIndex)
    		{
    			default:
    				break;
    			case 0:
    				context = new SM_Context();
    				ResetAp();
    				ResetEp();
    				break;
    			case 1:
    				context = new SM_Context();
    				ResetEp();
    				break;
    			case 2:
    				context = new SM_Context();
    				ResetAp();
    				WhatEverThisDoes();
    				break;
    		}
    	}
    }
    
    private void ResetAp()
    {
    	// ...
    }
    
    private void ResetEp()
    {
    	// ...
    }
    
    private void WhatEverThisDoes()
    {
    	// ...
    }
    
    private void btnAP_Reset(object sender, EventArgs e)
    {
    	ResetAp();
    }
    
    private void btnEP_Reset(object sender, EventArgs e)
    {
    	ResetEp();
    }
    
    private void headEditPassword_Loaded(object sender, EventArgs e)
    {
    	WhatEverThisDoes();
    }

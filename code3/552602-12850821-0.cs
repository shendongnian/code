    // Create a reference to the model being used to instantiate the window
    // and let the IoC import the model. If you set the PartCreationPolicy
    // as Shared for the Export of SomeOtherModel, then no matter where you are
    // in the application, you'll always be acting against the same instance.
    [Import]
    private SomeOtherModel _otherModel;
    public void ShowSomeOtherWindow()
    {
    	// use the caliburn IsActive property to see if the window is active
    	if( _otherModel.IsActive )
    	{
    		// if the window is active; nothing to do.
    		return;
    	}
    
    	// create some settings for the new window:
    	var settings = new Dictionary<string, object>
    				   {
    						   { "WindowStyle", WindowStyle.None },
    						   { "ShowInTaskbar", false },
    				   };
    
    	// show the new window with the caliburn IWindowManager:
    	_windowManager.ShowWindow( _otherModel, null, settings );
    }

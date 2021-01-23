    public Result SomeMethod()
    {
    	_doneHandler = new EventWaitHandle(false, EventResetMode.ManualReset);
    
        Popup popup = new Popup();
    
        popup.Closed += PopupClosedHandler;
        popup.ShowPopup();
    
    
        // This will wait until it is SET.  You can pass a TimeSpan 
    	// so that you do not wait forever.
    	_doneHandler.WaitOne();
       // Other stuff after the 'block'
    
    }
    
    private EventWaitHandle _doneHandler;
    
    void PopupClosedHandler(EventArgs<PopupEventArgs> args)
    {
        Result result = args.Result;
    	
    	_doneHandler.Set();
    }

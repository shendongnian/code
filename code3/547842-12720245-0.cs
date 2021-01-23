    public void BackgroundWorkerMethod()
    {
    	try
    	{
    		// do work
    	}
    	catch (Exception e)
    	{
    		uiObject.Invoke(new Action(() => {
    			// now you are on the UI thread
    			Message.ShowMessage(e.Message);
    		});
    	}
    }

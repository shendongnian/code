    private void View_Closing(object sender, CancelEventArgs e)
    {
    	UIGlobal.SelfThreadedDialogs.ForEach(k =>
    	{
    		try
    		{
    			if (k != null && !k.Dispatcher.HasShutdownStarted)
    			{
    				k.Dispatcher.InvokeShutdown();
    				//k.Dispatcher.Invoke(new Action(() => { k.Close(); }));
    			}
    		}
    		catch { }
    	});
    }

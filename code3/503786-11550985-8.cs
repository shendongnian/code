    private static bool ExitInternal()
    {
    	bool flag = false;
    	lock (Application.internalSyncObject)
    	{
    		if (Application.exiting)
    		{
    			return false;
    		}
    		Application.exiting = true;
    		try
    		{
    			if (Application.forms != null)
    			{
    				foreach (Form form in Application.OpenFormsInternal)
    				{
    					if (form.RaiseFormClosingOnAppExit())
    					{
    						flag = true;
    						break;
    					}
    				}
    			}
    			if (!flag)
    			{
    				if (Application.forms != null)
    				{
    					while (Application.OpenFormsInternal.Count > 0)
    					{
    						Application.OpenFormsInternal[0].RaiseFormClosedOnAppExit();
    					}
    				}
    				Application.ThreadContext.ExitApplication();
    			}
    		}
    		finally
    		{
    			Application.exiting = false;
    		}
    	}
    	return flag;
    }

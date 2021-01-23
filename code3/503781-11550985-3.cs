    private static void ExitCommon(bool disposing)
    {
    	lock (Application.ThreadContext.tcInternalSyncObject)
    	{
    		if (Application.ThreadContext.contextHash != null)
    		{
    			Application.ThreadContext[] array = new Application.ThreadContext[Application.ThreadContext.contextHash.Values.Count];
    			Application.ThreadContext.contextHash.Values.CopyTo(array, 0);
    			for (int i = 0; i < array.Length; i++)
    			{
    				if (array[i].ApplicationContext != null)
    				{
    					array[i].ApplicationContext.ExitThread();
    				}
    				else
    				{
    					array[i].Dispose(disposing);
    				}
    			}
    		}
    	}
    }
    // System.Windows.Forms.ApplicationContext
    /// <summary>Terminates the message loop of the thread.</summary>
    /// <filterpriority>1</filterpriority>
    public void ExitThread()
    {
    	this.ExitThreadCore();
    }

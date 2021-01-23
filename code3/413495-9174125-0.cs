    public static class FailureMessagebox
    {
    	private static bool _hasBeenSuccessful = true;
    	
    	public static void ShowIfFailure(Action someAction)
    	{
    		try
    		{
    			someAction();
    			_hasBeenSuccessful = false;
    		}
    		catch (Exception err)
    		{
    			if (_hasBeenSuccessful)
    				MessageBox.Show(ex.Message);
    				
    			_hasBeenSuccessful = false;
                        throw;
    		}
    	}
    }

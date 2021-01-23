    public abstract class CloseableViewModel
    {
    	public event EventHandler ClosingRequest;
    	
    	protected void OnClosingRequest()
    	{
    		if (this.ClosingRequest != null)
    		{
    			this.ClosingRequest(this, EventArgs.Empty);
    		}
    	}
    }

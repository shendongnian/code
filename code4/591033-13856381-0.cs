    public class ServiceProxy : ClientBase<IService>, IService>, IDisposable
    {
      public Response DoAction(Request request)
      {
        return Channel.DoAction(request);
      }
      private bool disposed;
      protected virtual void Dispose(bool disposing)
      {
    	if (!this.disposed)
    	{
    		if (disposing)
    		{
    			if (base.State == CommunicationState.Faulted)
    			{
    				this.Abort();
    			}
    			else if (base.State != CommunicationState.Closed)
    			{
    				try
    				{
    					this.Close();
    				}
    				catch (Exception exc)
    				{
    					this.Abort();
    				}
    			} 
    			disposed = true;
    		}
    	}    	
    }

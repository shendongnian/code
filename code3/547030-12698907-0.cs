    public abstract class BatchLoggerBase
    {
    	protected readonly object SyncRoot;
    	
    	protected BatchLoggerBase(object syncRoot)
    	{
    		if (syncRoot == null)
    			throw new ArgumentNullException("syncRoot");
    			
    		this.SyncRoot = syncRoot;
    	}
    }

    public class SyncDispatcher : IDisposable
    {
    	private static object _lock = new object();
    	private static Dictionary<object, SyncDispatcher> _container = new Dictionary<object, SyncDispatcher>();
    
    	private AutoResetEvent _syncEvent = new AutoResetEvent(true);
    
    	private SyncDispatcher() { }
    
    	private void Lock()
    	{
    		_syncEvent.WaitOne();
    	}
    
    	public void Dispose()
    	{
    		_syncEvent.Set();
    	}
    
    	public static SyncDispatcher Enter(object obj)
    	{
    		var objDispatcher = GetSyncDispatcher(obj);
    		objDispatcher.Lock();
    
    		return objDispatcher;
    	}
    
    	private static SyncDispatcher GetSyncDispatcher(object obj)
    	{
    		lock (_lock)
    		{
    			if (!_container.ContainsKey(obj))
    			{
    				_container.Add(obj, new SyncDispatcher());
    			}
    
    			return _container[obj];
    		}
    	}
    }

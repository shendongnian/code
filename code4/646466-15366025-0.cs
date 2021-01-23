    public class EntityFactory
    {
    
    	private static Dictionary<string, EntityObject> _entityObjects = new Dictionary<string, EntityObject>();
    	private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
    
    	public EntityObject CreateEntity(string name)
    	{
    		EntityObject result = null;
    
    		try
    		{
    				
    			if (!_entityObjects.TryGetValue(name, out result))
    			{
    				Lock.EnterWriteLock();
    				try
    				{
    					if (!_entityObjects.TryGetValue(name, out result))
    					{
    						// initialisation code here
    						result = new EntityObject() {Name = name};
    						_entityObjects[name] = result;
    					}
    				}
    				finally
    				{
    					Lock.ExitWriteLock();
    				}
    			}
    		}
    		finally
    		{
    			Lock.ExitUpgradeableReadLock();
    		}
    
    		return result;
    
    	}
    }

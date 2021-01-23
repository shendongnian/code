    public class EntityFactory
    {
        private static Dictionary<string, Func<EntityObject>> _entityObjects = new Dictionary<string, Func<EntityObject>>();
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
    
        public EntityObject CreateEntity(string name)
        {
            Func<EntityObject> result = () => null;
    
    		if (!_entityObjects.TryGetValue(name, out result))
    		{
    			Lock.EnterWriteLock();
    			try
    			{
    				if (!_entityObjects.TryGetValue(name, out result))
    				{
    					result = () =>
    						{
    							// initialisation code here
    							var entity = new EntityObject { Name = name };
    							return entity;
    						};
    					_entityObjects[name] = result;
    				}
    			}
    			finally
    			{
    				Lock.ExitWriteLock();
    			}
    		}
    
            return result();
        }
    }

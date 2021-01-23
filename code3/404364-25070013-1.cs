    /// <summary>
    /// Represents a collection of pools for one or more object types.
    /// </summary>
    public class Pooler
    {
    	private readonly List<IPool> _pools;
    
    	public Pooler()
    	{
    		_pools = new List<IPool>();
    	}
    
    	public void DefineType<T>(int initialCapacity, Pool<T>.Create createHandler, Pool<T>.Reset resetHandler)
    	{
    		var p = new Pool<T>(initialCapacity, createHandler, resetHandler);
    		_pools.Add(p);
    	}
    
    	public T Get<T>()
    	{
    		var p = GetPool(typeof (T));
    		if (p == null)
    			throw new Exception(string.Format("Pooler.Get<{0}>() failed; there is no pool for that type.", typeof(T)));
    
    		return ((Pool<T>)p).Get();
    	}
    
    	public void Return(object item)
    	{
    		var p = GetPool(item.GetType());
    		if (p == null)
    			throw new Exception(string.Format("Pooler.Get<{0}>() failed; there is no pool for that type.", item.GetType()));
    
    		p.Return(item);            
    	}
    
    	private IPool GetPool(Type itemType)
    	{
    		foreach (var p in _pools)
    		{
    			if (p.ItemType == itemType)
    			{
    				return p;
    			}
    		}
    
    		return null;
    	}
    }

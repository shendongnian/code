    /// <summary>
    /// Allows code to operate on a Pool<T> without casting to an explicit generic type.
    /// </summary>
    public interface IPool
    {
    	Type ItemType { get; }
    	void Return(object item);
    }
    	
    /// <summary>
    /// A pool of items of the same type.
    /// 
    /// Items are taken and then later returned to the pool (generally for reference types) to avoid allocations and
    /// the resulting garbage generation.
    /// 
    /// Any pool must have a way to 'reset' returned items to a canonical state.
    /// This class delegates that work to the allocator (literally, with a delegate) who probably knows more about the type being pooled.
    /// </summary>    
    public class Pool<T> : IPool
    {
    	public delegate T Create();
    	public readonly Create HandleCreate;
    
    	public delegate void Reset(ref T item);
    	public readonly Reset HandleReset;
    
    	private readonly List<T> _in;
    
    #if !SHIPPING
    	private readonly List<T> _out;
    #endif
    
    	public Type ItemType
    	{
    		get
    		{
    			return typeof (T);   
    		}            
    	}
    
    	public Pool(int initialCapacity, Create createMethod, Reset resetMethod)
    	{
    		HandleCreate = createMethod;
    		HandleReset = resetMethod;
    
    		_in = new List<T>(initialCapacity);            
    		for (var i = 0; i < initialCapacity; i++)
    		{
    			_in.Add(HandleCreate());
    		}
    #if !SHIPPING
    		_out = new List<T>();            
    #endif
    	}
    
    	public T Get()
    	{
    		if (_in.Count == 0)
    		{
    			_in.Add(HandleCreate());
    		}
    
    		var item = _in.PopLast();
    #if !SHIPPING
    		_out.Add(item);
    #endif
    		return item;
    	}
    
    	public void Return( T item )
    	{
    		HandleReset(ref item);
    #if !SHIPPING
    		Debug.Assert(!_in.Contains(item), "Returning an Item we already have.");
    		Debug.Assert(_out.Contains(item), "Returning an Item we never gave out.");
    		_out.Remove(item);
    #endif
    		_in.Add(item);
    	}
    
    	public void Return( object item )
    	{
    		Return((T) item);
    	}
    
    #if !SHIPPING
    	public void Validate()
    	{
    		Debug.Assert(_out.Count == 0, "An Item was not returned.");
    	}
    #endif
    }

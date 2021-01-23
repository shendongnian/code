    public class NodeGrid<T>
    {
    	public T PassableType { get; private set; }
    	
    	public bool IsPassable(params T[] passableTypes)
    	{
    		return IsPassable((IEnumerable<T>)passableTypes);
    	}
    	
    	public bool IsPassable(IEnumerable<T> passableTypes)
    	{
    		foreach(T passType in passableTypes)
    		{
    			if (EqualityComparer<T>.Default.Equals(this.PassableType, passType))
    				return true;
    		}
    		
    		return false;
    	}
    }

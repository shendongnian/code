    public class CageRegistry
    {
    	private List<Type> _allowedTypes = new List<Type>();
    	public IEnumerable<Type> AllowedTypes{get{return _allowedTypes;}}
    
    	public bool TryAdd(Type type)
    	{
    		if(ImplementsInterface(type, typeof(ICageable)))// for approach with attributes code is pretty similar
    		{
    			_allowedTypes.Add(type);
    			return true;
    		}
    		return false;
    	}
    }

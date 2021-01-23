    public class MyTypedDict
    {
    	private Dictionary<Type, object> Values = new Dictionary<Type, object>();
    	
    	public T Get<T>()
    	{
    		object untypedValue;
    		if (Values.TryGetValue(typeof(T), out untypedValue))
    			return (T)untypedValue;
    		return default(T);
    	}
    	
    	public void Set<T>(T value)
    	{
    		Values[typeof(T)] = value;
    	}
    }

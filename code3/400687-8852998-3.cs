    public static dynamic SuperDuperInvoke2(object target, string methodName, params ConvertableProxy[] args){
    	return SuperDuperInvoke(target,methodName,args);
    }
    
    public class ConvertableProxy{
    	private IConvertible _value;
    	public ConvertableProxy(IConvertible value){
    		_value =value;
    	}
    	
    	//Automatically convert strings to proxy
    	public static implicit operator ConvertableProxy(string value){
    		return new ConvertableProxy(value);
    	}
    	public static implicit operator bool(ConvertableProxy proxy)
    	{
    		return proxy._value.ToBoolean(null);
    	}
        public static implicit operator int(ConvertableProxy proxy)
    	{
    		return proxy._value.ToInt32(null);
    	}
        public static implicit operator string(ConvertableProxy proxy)
    	{
    		return proxy._value.ToString(null);
    	}
    	//.. Add Char, DateTime, etc.
    	
    
    }

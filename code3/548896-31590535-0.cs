    public void Write<T>(string key, T value)
    {
    	var settings = ApplicationData.Current.LocalSettings;
    
    	if (typeof(T).GetTypeInfo().IsEnum)
    	{
    		settings.Values[key] = Convert.ChangeType(value, Enum.GetUnderlyingType(typeof(T)));
    		return;
    	}
    
    	settings.Values[key] = value;
    }
    
    public bool TryRead<T>(string key, out T value)
    {
    	var settings = ApplicationData.Current.LocalSettings;
    
    	object tmpValue;
    	if (settings.Values.TryGetValue(key, out tmpValue))
    	{
    		if (tmpValue == null)
    		{
    			value = default(T);
    			return true;
    		}
    				
    		if (typeof(T).GetTypeInfo().IsEnum)
    		{
    			value = (T)Enum.ToObject(typeof(T), tmpValue);
    			return true;
    		}
    				
    		if (tmpValue is T)
    		{
    			value = (T) tmpValue;
    			return true;
    		}
    	}
    
    	value = default(T);
    	return false;
    }

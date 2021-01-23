    public T Convert<T>(string input, T defaultVal)
    {
    	var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
    	if(converter != null)
    	{
    		return (T)converter.ConvertFromString(input);
    	}
    	return defaultVal;
    }
    
    public T Convert<T>(string input)
    {
    	return Convert(input, default(T));
    }

    public List<string> GetValues(Type enumType)
    {  	
    	if(typeof(Enum).IsAssignableFrom(enumType))
    	{
    		Array values = Enum.GetValues(enumType);
    		List<string> result = new List<string>(values.Length);
    		foreach (var @enum in values)
    		{
    			result.Add(string.Format("Value {0} Name {1}", (int)@enum, @enum));
    		}
    		return result;
    	}
    	throw new ArgumentException("enumType");
    }

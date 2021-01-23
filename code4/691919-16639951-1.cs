    public List<string> GetValues(Type enumType)
    {  	
    	if(typeof(Enum).IsAssignableFrom(enumType))
    	{
            List<string> result = new List<string>();
    		var values = Enum.GetValues(enumType);
    		
    		foreach (var @enum in values)
    		{
    			result.Add(string.Format("Value {0} Name {1}", (int)@enum, @enum));
    		}
    		return result;
    	}
    	throw new ArgumentException("enumType");
    }

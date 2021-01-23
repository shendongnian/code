    public List<string> GetValues(Type enumType)
    {
    	if(typeof(Enum).IsAssignableFrom(enumType))
    	{
    		var values = Enum.GetValues(enumType);
    		
    		return values.Cast<object>()
    					 .Select(@enum => string.Format("Value {0} Name {1}", (int)@enum, @enum))
    					 .ToList();
    	}
    	throw new ArgumentException("enumType should describe enum");
    }

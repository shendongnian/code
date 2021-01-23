    /// <summary>
    /// Returns with suffix removed, if present
    /// </summary>
    public static string TrimIfEndsWith(
    	this string	value,
    	string	suffix)
    {
    	return	
    		value.EndsWith(suffix) ?
    			value.Substring(0, value.Length - suffix.Length) :
    			value;
    }

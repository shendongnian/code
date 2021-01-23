    /// <summary>
    /// This function tries to cast the input object to a integer or returns the default value
    /// </summary>
    /// <param name="objInput">object to check</param>
    /// <param name="intDefault">optional default value</param>
    /// <returns>Object cast to string or default value</returns>
    public static int ValueOrDefaultForInteger(object objInput, int intDefault = 0)
    { 
	 if (objInput == DBNull.Value | objInput == null)
		return intDefault;
	 return Convert.ToInt32(objInput);
    }

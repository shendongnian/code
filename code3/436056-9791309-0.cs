    /// <summary>
    /// Gets a value from the current session, if the type is correct and present
    /// </summary>
    /// <param name="key">The session key</param>
    /// <param name="defaultValue">The default value</param>
    /// <returns>Returns a strongly typed session object, or default value</returns>
    public static T GetValueOrDefault<T>(this StateBag source, string key, T defaultValue)
    {
        // check if the session object exists, and is of the correct type
    	if (source[key] == null || !(source[key] is T))
    	{
            return defaultValue;
    	}
    
        // return the session object
    	return (T)source[key];
    }

    /// <summary>
    /// Safe converting to any type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">Value to convert</param>
    /// <param name="defaultValue">Default value, sets type of return value</param>
    /// <returns>Converted value or defaul when error</returns>
    public static T safeConvert<T>(object value, T defaultValue)
    {
        try
        {
            return value == null ? default(T) : 
                (T)Convert.ChangeType( value, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T) );
        }
        catch
        {
            return defaultValue;
        }
    }

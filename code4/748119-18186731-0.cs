    public static string AsString(this JObjectValue jsonValue, string defaultValue = default(T))
    {
    	if (jsonValue != null)
    		return jsonValue.ToString();
    	else
    		return defaultValue;
    }
    
    public static T As<T>(this JObjectValue jsonValue, T defaultValue = default(T))
    {
    	if (jsonValue != null)
    		return jsonValue.Value<T>();
    	else
    		return defaultValue;
    }

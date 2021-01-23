    public T AttributeValue<T>(XmlNode node, string attributeName)  
    {
        if (node.Attributes[attributeName] != null && !string.IsNullOrEmpty(node.Attributes[attributeName].Value))
        {
            var value = node.Attributes[attributeName].Value;
    		var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        	return (T)Convert.ChangeType(value, type);
        }
        else
        {
            if (typeof(T) == typeof(int))
                return (T)(object)(-1);
            
    	    return default(T);
        }
    }

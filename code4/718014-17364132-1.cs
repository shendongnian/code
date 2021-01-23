    public T AttributeValue<T>(XmlNode node, string attributeName)  
    {
        var value = new object();
    
        if (node.Attributes[attributeName] != null && !string.IsNullOrEmpty(node.Attributes[attributeName].Value))
        {
            value = node.Attributes[attributeName].Value;
        }
        else
        {
            if (typeof(T) == typeof(int))
                value = -1;
            else if (typeof(T) == typeof(DateTime))
                value = DateTime.MinValue;
            else if (typeof(T) == typeof(string))
                value = null;
            else if (typeof(T) == typeof(bool?))
                value = null;
        }
    	
    	var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        return (T)Convert.ChangeType(value, type);
    }

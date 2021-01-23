    public static string Format(this string source, object replacements)
    {
    	if (string.IsNullOrWhiteSpace(source) || replacements == null)
    	{
    		return source;
    	}
    
    	IDictionary<string, string> replacementsDictionary = new Dictionary<string, string>();
    
    	foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(replacements))
    	{
    		string token = propertyDescriptor.Name;
    		object value = propertyDescriptor.GetValue(replacements);
    
    		replacementsDictionary.Add(token, (value != null ? value.ToString() : String.Empty));
    	}
    
    	return Format(source, replacementsDictionary);
    }

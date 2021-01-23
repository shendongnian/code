    public static string GetControlValue(Control c) 
    {
    	// This code is copied as-is from BaseValidator.GetControlValidationValue method
    	PropertyDescriptor prop = BaseValidator.GetValidationProperty(c);
    	if (prop == null) { 
    		return null;
    	} 
    	object value = prop.GetValue(c); 
    	if (value is ListItem) {
    		return((ListItem) value).Value;
    	}
    	else if (value != null) { 
    		return value.ToString();
    	} 
    	else { 
    		return string.Empty;
    	} 
    }

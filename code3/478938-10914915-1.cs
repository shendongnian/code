    public bool ValidateRequired(string property, string value, string errorMessage)
    {
    	bool isValid = true;
    
    	if (value == null || value == string.Empty)
    	{
    		AddError(property, errorMessage, false);
    		isValid = false;
    	}
    	else RemoveError(property, errorMessage);
    	RaiseErrorsChanged(property);
    	return isValid;
    }
    
    public bool ValidateRegularExpression(string property, string value, string expression, string errorMessage)
    {
    	...
    }
    
    public bool ValidateTotal(string property,int 1, int 2, int 3, int total, string errorMessage)
    {
    	if((1+2+3) != total)
    		AddError(property, errorMessage, false);
    	else RemoveError(property, errorMessage);
    }

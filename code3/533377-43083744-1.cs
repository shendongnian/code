    bool IsValidationError(ErrorProvider errorProvider, Control.ControlCollection controlCollection)
    {
    	foreach(Control child in controlCollection)
    	{
    		// The child or one of its children has an error.
    		if (!errorProvider.GetError(child).IsNullOrEmpty() || IsValidationError(errorProvider, child.Controls))
    			return true;
    	}
    
    	return false;
    }

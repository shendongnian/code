    public string CheckPhoneNumber(string Number)
    {
    
    
    	if (Number.ToString().Contains("-")) {
    		Number = Number.Replace("-", "");
    
    	}
    
    
    	if (Number.ToString().Contains("(")) {
    		Number = Number.Replace("(", "");
    		Number = Number.Replace(")", "");
    
    	}
    
    	if (!Information.IsNumeric(Number)) {
    		return "Error";
    	} else {
    		return Number;
    	}
    
    }

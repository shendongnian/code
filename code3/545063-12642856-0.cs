    public string FormatNumber(double number)
    {
    	string stringRepresentation = number.ToString();
    	
    	if (stringRepresentation.Length > 5)
    		stringRepresentation = stringRepresentation.Substring(0, 5);
    	
    	if (stringRepresentation.Length == 5 && stringRepresentation.EndsWith("."))
    		stringRepresentation = stringRepresentation.Substring(0, 4);
    	
    	return stringRepresentation.PadLeft(5);
    }

    private List<string> ValidateInput(string ErrorMessage, TextBox txtInput, ValidatationType validationType)
    {
        List<string> errormessages = new List<string>();
 
        if (validatationType  == ValidationType.NoNullValues)
        { 
             
	        if (txtInput.Text.Equals(String.Empty))
                {
                    errormessages.Add(ErrorMessage); 
                }
 		
        }
        if (validatationType  == ValidationType.Integer)
        { 
             
            int number;
            if (Int32.TryParse(value, out number))
            {
                errormessages.Add(ErrorMessage); 
            }
 		
        }
        // etc. etc.
    }

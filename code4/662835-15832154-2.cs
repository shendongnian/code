    string[] stringsToValidate = new string[] { 
                                           "333TEST",
                                           "TEST4444-1234-AB",
                                           "ABCD12AB-1234-99",
                                           "ABCD2345-1234-AB",
                                           "PPP12AA-9876"
                                       };
    string strForMatching = "AAAAXXXX-NNNN-AA";
    
    var validator = new StringValidator();
    
    foreach(var strToValidate in stringsToValidate)
    {
    	bool isValid = validator.ValidateString(strForMatching, strToValidate);
    	Console.WriteLine(isValid);
    }

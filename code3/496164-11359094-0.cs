        if (!int.TryParse(age, out intAge))
        {
            inputOk = false;  
            errorMessage = "Enter an age in numbers!";  
        }
        else
        {
        // Check input  
        if (intAge < 1)  
            {  
                inputOk = false;  
                errorMessage = "Please enter 1 or higher!";  
            }
        }

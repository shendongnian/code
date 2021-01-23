    int intAge;
    
    if (!int.TryParse(age, intAge))
    {
        MessageBox.Show(...
    }
    else
    {
        if (intAge < 1)
            {
                inputOk = false;
                errorMessage = "Please enter 1 or higher!";
            }
    }

    bool RunValidation()
    {
        if (NameEntered == string.Empty)
        {
            MessageBox.Show("No name has been entered");
            return false;
        }
        return true;
    }
    
    void CreateUser()
    {
        if(RunValidation())
        {
    
            //Run more code
         }
    }

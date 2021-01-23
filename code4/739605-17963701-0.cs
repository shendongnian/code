    void IsFormValid(this, e)
    {
        bool result = ValidateAllControls();
    
        if(!result)
            return;
    
        // Rest of the execution
    }
    bool ValidateAllControls()
    {
        if(!control1.IsValid)
            return false;
        if(!control2.IsValid)
            return false;
        if(!control3.IsValid)
            return false;
        return true;
    }

    bool ResultUserExistence = register.CheckUniquenessUserID(txtUserId.Text);
    
    if (ResultUniquenessEmail == null)
    {
        continue through code...
    }
    
    else
    {
        var err As new CustomValidator()
        err.ValidationGroup = "UserUniqueness";
        err.IsValid = False;
        err.ErrorMessage = "Please choose a different user name. The current user name is already registered.";
        Page.Validators.Add(err);    
    
    }

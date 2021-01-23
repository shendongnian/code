    string lastName = await UserInformation.GetLastNameAsync();
    
    if (string.IsNullOrEmpty(lastName))
    
    {
    
        rootPage.NotifyUser("No Display Name was returned", NotifyType.StatusMessage);
    
    }
    
    else
    
    {
    
        LastName.Text = lastName;
    
    }

    string displayName = await UserInformation.GetDisplayNameAsync();
    
    if (string.IsNullOrEmpty(displayName))
    
    {
    
         rootPage.NotifyUser("No Display Name was returned", NotifyType.StatusMessage);
    
    }
    else
    
    {
    
        UserName.Text = displayName;
    
    }

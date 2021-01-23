    string firstName = await UserInformation.GetFirstNameAsync();
    
    if (string.IsNullOrEmpty(firstName))
    {
    
         rootPage.NotifyUser("No Display Name was returned", NotifyType.StatusMessage);
    
    }
    
    else
    
    {
    
       FistName.Text = firstName;
    
    }
     

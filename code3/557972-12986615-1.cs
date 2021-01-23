    Skype skype = new Skype();
    if (!skype.Client.IsRunning) // Return true if Skype is running.
        return;
    // skype.Friends throws out exception "Not Attached." if no valid account is logged in.
    foreach(User user in skype.Friends) 
    {
        if (user.OnlineStatus == TOnlineStatus.olsOnline)
        { /*Insert what you want...*/ }
                    
    } 

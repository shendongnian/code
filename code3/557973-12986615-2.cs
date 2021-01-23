    Skype skype = new Skype();
    // Return true if Skype is running.
    if (!skype.Client.IsRunning) 
        return;
    // User is not logged in.
    if (skype.CurrentUserStatus == TUserStatus.cusLoggedOut)
        return;
    // Friends
    foreach(User user in skype.Friends) 
    {
        if (user.OnlineStatus == TOnlineStatus.olsOnline)
        { /*Insert what you want...*/ }
                    
    } 

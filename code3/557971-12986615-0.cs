    Skype skype = new Skype();
    if (!skype.Client.IsRunning)
        return;
    foreach(User user in skype.Friends)
    {
        if (user.OnlineStatus == TOnlineStatus.olsOnline)
        { /*Insert what you want...*/ }
                    
    } 

    var events = (_ISkypeEvents_Event) _skype;
    events.UserAuthorizationRequestReceived += UserAuthorizationRequestReceived;
    try
    {
        _skype.Attach(8);
    }
    catch(COMException ce)
    {
        RaiseErrorEvent("Unable to attach to skype.", ce);
    }
    private void UserAuthorizationRequestReceived(SKYPE4COMLib.User puser)
    {
         if (do some user check here?? )
         {
             puser.IsAuthorized = true;
         }
    }

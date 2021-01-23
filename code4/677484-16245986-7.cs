    client.GetCompleted += (o, e) =>
                 {
                     // some code
                     if (Convert.ToInt64(eargs.Result) == 0)
                     {
                       UserID = Convert.ToInt64(eargs.Result);
                     }
                     // let UI thread know we've got the result
                     Dispatcher.Invoke( (Action)(() => { NotifyUIThread(UserID) } ));
                 }
    ...
    void NotifyUIThread(long UserId) //This runs on UI thread
    {
        if (UserID == -1)
           // WRONG RESULT <---
        else
           // RIGHT RESULT <---
    }
    

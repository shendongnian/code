    (from user in twitterCtx.User
     where user.UserID != "JoeMayo"
     select user).AsyncCallback(users => {
        // result is in users variable
        var user = users.SingleOrDefault();
        if(user != null)
        {
            // use user here.
        }
    }).SingleOrDefault();

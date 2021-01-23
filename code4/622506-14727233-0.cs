    var fIdent = User.Identity as FormsIdentity;
    if(fIdent != null)
    {
        string adminUserName = fIdent.Ticket.UserData;
        if(!String.IsNullOrEmpty(adminUserName))
        {
            // an Admin user is logged on as another user... 
        }
        else
        {
            // the user logged on directly (the typical scenario)
        }
    }

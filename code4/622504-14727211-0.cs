    if (Page.User.Identity != null && Page.User.Identity is FormsIdentity)
    {
       var ident = (FormsIdentity)Page.User.Identity;
       var ticket  = ident.Ticket;
       var AdminUserName = ticket.UserData;
    
       if (!String.IsNullOrEmpty(AdminUserName))
       {
          'An Admin user is logged on as another user... 
          'The variable AdminUserName returns the Admin user's name
          'To get the currently logged on user's name, use Page.User.Identity.Name
       }
       else
       {
          'The user logged on directly (the typical scenario)
       }
  }

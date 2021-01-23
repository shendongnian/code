    if (Page.User.Identity != null && Page.User.Identity is FormsIdentity) {
	    FormsIdentity ident = (FormsIdentity)Page.User.Identity;
	    FormsAuthenticationTicket ticket = ident.Ticket;
	    string AdminUserName = ticket.UserData;
	    if (!string.IsNullOrEmpty(AdminUserName)) {
	    //An Admin user is logged on as another user... 
	    //The variable AdminUserName returns the Admin user's name
	    //To get the currently logged on user's name, use Page.User.Identity.Name
	    } else {
		    //The user logged on directly (the typical scenario)
	    }
    }

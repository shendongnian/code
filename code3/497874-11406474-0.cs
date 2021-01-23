    const string IS_ADMIN_KEY; //this can be on a base class of page / master page
    Session[IS_ADMIN_KEY] = Roles.IsUserInRole("Admin"); // do this when logging in
    //Add this to page load
    bool isAdmin = Session[IS_ADMIN_KEY]; 
    if(isAdmin)) 
    { 
       // display the page 
    } else 
    { 
       // don't display the page 
    }

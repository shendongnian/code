    public ActionResult GetAdminPage()
    {
        var loggedInUserName = HttpContext.User.Identity.Name;
        var user = somesortofproviderlookupmethod(loggedInUserName);
        
        // Assume user is a bool and is true
        if (user)
        {
            return view("AdminPage");
        }
    }

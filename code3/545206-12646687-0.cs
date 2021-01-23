    public static CompanyHttpApplication CurrentApplication
    {
        // store application constants, active user counts, message of the day, and other things all users can see
        get { return (CompanyHttpApplication)HttpContext.Current.ApplicationInstance; }
    }
    public static Session CurrentSession
    {
        // store information for a single user — each user gets their own instance and can *not* see other users' sessions
        get { return HttpContext.Current.Session; }
    }

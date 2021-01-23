    public static class SessionManager
    {
        public static UserSession UserSession
        {
            set
            {                
               HttpContext.Current.Session["USER_SESSION"] = value;
            }
            get
            {
                var session = HttpContext.Current.Session;
                var userSession = session["USER_SESSION"] as UserSession;
                if (userSession == null)
                {
                    userSession = new UserSession ();
                    session["USER_SESSION"] = userSession;
                }
                return userSession;
            }
        }
    }

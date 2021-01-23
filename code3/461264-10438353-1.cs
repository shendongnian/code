    public static class Globals
    {
        public static UserSession TheUserSession
        {
            get
            {
                if ((HttpContext.Current.Session["UserSession"] == null))
                {
                    HttpContext.Current.Session.Add("UserSession", new CurrentUserSession());
                    return (CurrentUserSession)HttpContext.Current.Session["UserSession"];
                }
                else
                {
                    return (CurrentUserSession)HttpContext.Current.Session["UserSession"];
                }
            }
            set { HttpContext.Current.Session["UserSession"] = value; }
        }
    }

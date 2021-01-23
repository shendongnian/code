    public static class SessionFacade
    {
        public static int UserId
        {
            get {
                if (HttpContext.Current.Session["UserId"] == null)
                    HttpContext.Current.Session["UserId"] = 0;
                return (int)HttpContext.Current.Session["UserId"];
            }
            set {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        // ... and so on for your other variables
    }

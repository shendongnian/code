    public static class SessionAccess
    {
        public static Something SomethingSession
        {
            get
            {
                return Session["Something"] as Something;
            }
    
            set
            {
                Session["Something"] = value;
            }
        }
    }

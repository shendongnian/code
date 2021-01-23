    public static class SessionWrapper
    {
        public string Sid 
        { 
            get 
            { 
                var sid = Session["Sid"]; 
                return sid == null ? "" : sid.ToString(); 
            } 
            set 
            { 
                Session["Sid"] = value; 
            } 
        }
    }

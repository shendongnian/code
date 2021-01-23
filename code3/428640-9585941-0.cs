    public string UserId
    {
        get
        {
            string s = Session["UserId"];
            if (s == null)
            {
                s = ... Get UserID from somewhere, e.g. database
                Session["UserId"] = s;
            }
            return s;
        }
    }

    public int customerID
    {
        get { return Session["customerID"] == null? -1 : (int)Session["customerID"]; }
        set { Session["customerID"] = value; }
    }

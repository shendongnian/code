    public static int customerID
    {
        get { return session["customerID"] == null? -1 : (int)session["customerID"]; }
        set { session["customerID"] = value; }
    }

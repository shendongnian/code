    public bool IsLoggedIn()
    {
        // You will have to check for the keys, if they are present in the Session container, first.
        
        if(!Session.Containts("customer_id")
                || !Session.Contains("customer_username")
                || !Session.Contains("customer_ip"))
            return false;
        return Session["customer_id"] > 0
            && String.IsNullOrEmpty(Session["customer_username"])
            && Session["customer_ip"] = Request.ServerVariables("REMOTE_ADDR")
    }
    public void LogOut()
    {
        Session.Remove("customer_id");
        Session.Remove("customer_username");
        Session.Remove("customer_ip");
    }

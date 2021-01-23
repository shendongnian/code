    public bool IsLoggedIn()
    {
        // You will have to check for the keys, if they are present in the Session container
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

    [WebMethod]
    public static void ClearYourSessionValue()
    {
        // This will leave the key in the Session cache, but clear the value
        Session["YourKey"] = null;
        // This will remove both the key and value from the Session cache
        Session.Remove("YourKey");
    }

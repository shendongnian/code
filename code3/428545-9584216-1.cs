    [WebMethod]
    static public string DeleteItem(string id)
    {
        try
        {
            var api = new GoogleCalendarAPI(User.InternalUser());
            api.DeleteEvent(id);
            return "success";
        }
        catch(Exception ex)
        {
            log.fatal(ex);
            return "error";
        }
    }

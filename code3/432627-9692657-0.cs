    [AcceptVerbs(HttpVerbs.Post)]
    public PartialViewResult Register(string id, int classid) 
    {
        try
        {
            ... stuff
        }
        catch (DataException ex)
        { 
            return Javascript("alert('The user might have been already Assinged, Search Again to get the latest users');");
        }
    }

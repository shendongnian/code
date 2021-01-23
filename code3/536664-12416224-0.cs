    public virtual ActionResult SearchSite(MyQuery myQuery)
    {
         string sendBack = "info to send: " + myQuery.query;
         return Content(sendBack); 
    }

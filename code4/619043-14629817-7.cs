    [AcceptVerbs( HttpVerbs.Post )]
    [HttpPost]
    public ActionResult SetProperties ( string hotelPropertyAssignModel )
    {
        ...
        return new EmptyResult();
    }

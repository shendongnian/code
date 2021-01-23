    [AcceptVerbs( HttpVerbs.Post )]
    [HttpPost]
    public ActionResult SetProperties ( HotelAssignmentViewModel model )
    {
        ...
        return new EmptyResult();
    }

    //This method will (by default) come from calling [BASEURL]/PostDetails/GetDetails
    public ActionResult GetDetails()
    {
        var details = new PostDetailsModel();
        details.UserId = GetUserId();
        details.ViewNumber = GetViewNumber();
        ....
        //By default this looks for a view in the PostDetails folder 
        //by the name of your method (GetDetails)
        return View(details);
    }

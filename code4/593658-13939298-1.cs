    [Authorize]
    public ActionResult Test()
    {
        if(Request.IsAuthenticated)
        {
            string username = HttpContext.User.Identity.Name;
            return Content(username);         
        }
        else 
        {
            return Content("User is not authenticated");
        }
    }

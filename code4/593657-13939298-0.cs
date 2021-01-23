    [Authorize]
    public ActionResult Test()
    {
        string username = HttpContext.User.Identity.Name;
        return Content(username);         
    }

    [Authorize]
    public ActionResult SomeProtectedAction()
    {
        string username = User.Identity.Name;
        // something else ...
    }

    [ChildActionOnly]
    public ActionResult LogedInUser()
    {
        var user = new UserViewModel();
        if (Request.IsAuthenticated)
        {
            user.Nom_User = User.Identity.Name;
        }
        return PartialView(user);
    }

    [ChildActionOnly]
    public ActionResult LogedInUser()
    {
        if (!Request.IsAuthenticated)
        {
            return PartialView();
        }
        var user = new UserViewModel();
        user.Nom_User = User.Identity.Name;
        return PartialView(user);
    }

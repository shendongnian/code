    [Authorize]
    public ActionResult SomeAction()
    {
        using (UsersContext db = new UsersContext())
        {
            UserProfile user = db
                .UserProfiles
                .FirstOrDefault(u => u.UserName == User.Identity.Name);
            // do something with the profile
        }
    
        ...
    }

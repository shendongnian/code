    public ActionResult Index()
    {
        var roles = Roles.GetAllRoles();
        var users = from MembershipUser u in Membership.GetAllUsers()
                select new UserRoles()
                {
                    Name = u.UserName,
                    AllRolles = UserActiveRoles(u.UserName).ToArray()
                };
        return View(users);
    }

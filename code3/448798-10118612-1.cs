    public ActionResult Index()
    {
        var users = Membership.GetAllUsers().Cast<MembershipUser>();
        var model = new UsersViewModel
        {
            AvailableUsers = users.Select(u => new SelectListItem
            {
                Value = u.UserName,
                Text = u.UserName
            })
        };
        return View(model);
    }

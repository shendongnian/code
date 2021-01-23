    public ActionResult Index()
    {
        var users = Membership.GetAllUsers().Cast<MembershipUser>();
        var model = new UsersViewModel
        {
            AvailableUsers = users.Select(x => new SelectListItem
            {
                Value = x.UserName,
                Text = x.UserName
            })
        };
        return View(model); 
    }

    public ViewResult Index()
    {
       var roleFilter = "Group1";
        
       return View(new UserViewModel
                    {
                        Users = _userService.FindAll().Where(x => Roles.GetRolesForUser(x.UserName).Contains(roleFilter)),
                        Roles = new [] {roleFilter}
                    });
    }

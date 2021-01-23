    public ViewResult Index()
    {
       var roleFilter = Roles.GetRolesForUser().First(r => !r.equals("Admin"));
        
       return View(new UserViewModel
                    {
                        Users = _userService.FindAll().Where(x => Roles.GetRolesForUser(x.UserName).Contains(roleFilter)),
                        Roles = new [] {roleFilter}
                    });
    }

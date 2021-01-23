    public ViewResult Index(int? index)
    {
        if (Roles.IsUserInRole("Group Admin"))
        {
            string[] roles = Roles.GetRolesForUser();
            var accountController = new AccountController()
            var GroupUsers = accountController.UsersInGroup();

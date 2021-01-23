    protected override void Seed(EfDb context)
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (!WebSecurity.UserExists("john"))
            {
                WebSecurity.CreateUserAndAccount("john", "secret");
            }
            if (!Roles.GetRolesForUser("john").Contains("Administrator"))
            {
                Roles.AddUsersToRoles(new[] { "john" }, new[] { "Administrator" });
            }
           
        }

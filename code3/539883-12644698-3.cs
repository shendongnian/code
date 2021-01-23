        protected override void Seed(UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);
            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");
            if (!WebSecurity.UserExists("lelong37"))
                WebSecurity.CreateUserAndAccount(
                    "lelong37",
                    "password",
                    new {Mobile = "+19725000000", IsSmsVerified = false});
            if (!Roles.GetRolesForUser("lelong37").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] {"lelong37"}, new[] {"Administrator"});
        }

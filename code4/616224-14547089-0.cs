            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                            "DefaultConnection", "UserProfile", 
                            "UserId", "UserName", autoCreateTables: true);
            }
            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (!roles.RoleExists("Agent"))
            {
                roles.CreateRole("Agent");
            }
            AddUser("admin", "Admin", "123");
            AddUser("agent", "Agent", "123");
        } 

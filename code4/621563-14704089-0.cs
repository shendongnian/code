    using (CFAContext context = new CFAContext())
    {
        var roles = new List<Role> {
          new Role { RoleName = "Role 1" },
          new Role { RoleName = "Role 2" },
          new Role { RoleName = "Role 3" },
          new Role { RoleName = "Role 4" }
        };
        context.Users.Add(new User { UserName = "User 1", Roles = new List<Role> { roles[0], roles[1], roles[2] } });
        context.Users.Add(new User { UserName = "User 1", Roles = new List<Role> { roles[0], roles[1] } });
        context.Users.Add(new User { UserName = "User 1", Roles = new List<Role> { roles[0], roles[3] } });
        context.SaveChanges();
    }

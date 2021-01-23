    Role role1 = new Role { RoleName = "Role 1" }
    Role role2 = new Role { RoleName = "Role 2" }
    Role role3 = new Role { RoleName = "Role 3" }
    Role role4 = new Role { RoleName = "Role 4" }
    
    context.Users.Add(new User { UserName = "User 1", Roles = new List<Role> { role1, role2, role3 } });
        context.Users.Add(new User { UserName = "User 2", Roles = new List<Role> { role1,role2 } });
        context.Users.Add(new User { UserName = "User 3", Roles = new List<Role> { role1, role4 } });
        context.SaveChanges();

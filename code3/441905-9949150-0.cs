    User u = new User {
        Login = login,
        Password = password,
        Status = 1,
    };
    ctx.Users.Add(u);
    u.Roles.Add(r);
    ctx.SaveChanges();

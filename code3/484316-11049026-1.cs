    using (Entities db = new Entities())
    {              
        var user = new User();
        // fill user data..
        var newRole = db.Role.FirstOrDefault(r => r.ID == 1);
        user.roles.AddObject(newRole);
        db.users.AddObject(user);
        db.SaveChanges();
    }

        using (var db = new MyContext())
        {
            var user = new User { UserRole = new UserRole { RoleID = 1, UserId = 1 } };
            db.Users.Add(user);
            db.SaveChanges();
        } 

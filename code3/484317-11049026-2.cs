    using (Entities db = new Entities())
    {              
        var user = new User();
        // fill user data..
        var newRole = db.Role.FirstOrDefault(r => r.ID == 1);
        if(newRole!=null)
        {
            user.roles.AddObject(newRole);
            db.users.AddObject(user);
            db.SaveChanges();
        }
    }
    //Edit - Updating db
    using (Entities db = new Entities())
    { 
        var existingUser = db.User.FirstOrDefault(r => r.ID == 100);
        if(existingUser !=null)
        {
           existingUser.Name = "New name";
           db.SaveChanges();
        }
    }

    var user = new User { UserRole = new UserRole() };
    
    using (Database database = new Database())
    {                
          database.User.Add(user);
          database.SaveChanges();  //it is giving error here.
    }

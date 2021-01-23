    public void Foo(int id, string name) {
       var user = Db.Users.Local.SingleOrDefault(u => u.Id == id);
       if (user == null) {
          user = new User { Id = id };
          Db.Users.Attach(user);
       } 
       user.Name = name;
       Db.SaveChanges();
    }

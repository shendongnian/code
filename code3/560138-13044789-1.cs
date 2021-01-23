    public void ChangePassword(int userId, string password)
    {
      var user = new User() { Id = userId, Password = password };
      using (var db = new MyEfContextName())
      {
        db.Users.Attach(user);
        db.Entry(user).Property(x => x.Password).IsModified = true;
        db.SaveChanges();
      }
    }

    using (var context = new MyDbContext(ConnectionString))
    {
      var users = context.Users.Where(x => x.Name == userName && x.Password == password);
      return users.FirstOrDefault(x =>  x.Password.Equals(password)));
    }

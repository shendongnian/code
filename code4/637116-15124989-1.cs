    public List<User> Get()
    {
        using (var db = new MyContext())
        {
            return (from u in db.Users
                    orderby u.FirstName
                    select new User()
                    {
                        Id = u.pkUser,
                        Username = u.Username,
                        Password = u.Password,
                        Active = u.Active
                    }).ToList();
        }
    }

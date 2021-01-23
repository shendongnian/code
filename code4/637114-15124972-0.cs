    using (var db = new MyContext())
    {
        var query = from u in db.Users
                    orderby u.FirstName
                    select u;
        return query.AsEnumerable().Select(item => 
                     new User 
                         { 
                            Id = item.pkUser,
                            Username = item.Username,
                            Password = item.Password,
                            Active = item.Active
                         }).ToList();
    }

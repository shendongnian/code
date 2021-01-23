    using (var session = Database.OpenSession())
    {
        var q = from x in session.Query<User>()
               where x.UserName == username && x.Password==EncodePassword(password)
                select x;
        if (q.Count() > 0)
         {
             result = true;
         }
    }

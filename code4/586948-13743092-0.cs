    using (var session = _sessionFactory.OpenSession())
    {
        var transaction = session.BeginTransaction();
        john.Name = "John";
        Phone home = new Phone
                         {
                             Type = "Home",
                             Number = "12345"
                         };
         john.PhoneNumbers.Add(home.Type, home);
         session.Save(john);
         transaction.Commit();
    }

        using (var db = new DataContext())
        {
            User user = new User()
            {
                FullName = newUserName,
                ID = Guid.NewGuid()
            };
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
        }

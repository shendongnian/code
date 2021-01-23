    public String AddUser(string newUserName)
    {
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
        return newUserName;
    }

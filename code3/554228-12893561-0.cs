    public void saveNewUser(User u, Role r)
    {
        using (FormValueEntities db = new FormValueEntities())
        {
            db.Role.Add(r);
            db.User.Add(u);
            db.SaveChanges();
        }
    }

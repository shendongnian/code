    public void InsertUsers(IEnumerable<User> Users)
    {
        using (LaCalderaEntities Context = new LaCalderaEntities())
        {
            UserBL UserBl = new UserBL(Context);
            UserBl.InsertUsers(Users);
            Context.SaveChanges();
        }
        foreach (var user in Users)
        {
            Console.Writeline(user.id);
        }
    }

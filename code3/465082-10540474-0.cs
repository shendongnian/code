    public int[] InsertUsers(IEnumerable<User> Users)
    {
        using (LaCalderaEntities Context = new LaCalderaEntities())
        {
            UserBL UserBl = new UserBL(Context);
            UserBl.InsertUsers(Users);
            Context.SaveChanges();
    //At This Point Your Users objects have ID's
    return Users.Select(u=>u.ID).ToArray()
        }
    }

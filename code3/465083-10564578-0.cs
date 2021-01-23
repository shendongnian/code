    public void InsertUsers(ref IEnumerable<User> Users) 
    { 
        using (LaCalderaEntities Context = new LaCalderaEntities()) 
        { 
            UserBL UserBl = new UserBL(Context); 
            UserBl.InsertUsers(Users); 
            Context.SaveChanges(); 
        } 
    } 

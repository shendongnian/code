    public string AddAccount()
    {
        myContext db=new myContext();
        //id is not initialized, because I'm assuming it has an identity specification
        db.Accounts.Add(new Account() { Created = DateTime.Now.ToUniversalTime()});
        db.SaveChanges();
        return "something";
    }

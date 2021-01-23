    public MyDbContext(): base("MyDbContext")
    {
    #if DEBUG
        ((IObjectContextAdapter)this).ObjectContext.SavingChanges += new EventHandler(objContext_SavingChanges);
    #endif
    }

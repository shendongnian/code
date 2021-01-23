    private DatabaseContext dbContext;
    private DatabaseContext DbContext
    {
        get { return dbContext ?? (dbContext = new DatabaseContext()); }
    }

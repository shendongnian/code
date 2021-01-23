    public DbContext()
    {
        IDbContextFactory defaultFactory; //initialize your default here
        DbContext(defaultFactory);
    }
    public DbContext(IDbContextFactory factory)
    {
    }

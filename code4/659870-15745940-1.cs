    private IDbConnection db;
    public virtual IDbConnection Db
    {
        get { return db ?? (db = TryResolve<IDbConnectionFactory>().Open()); }
    }

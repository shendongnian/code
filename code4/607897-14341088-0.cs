    // Associate with first entity
    public Context1 : ObjectContext
    {
        prop IDbSet<A> ADbSet{ get; set; }
        ...
    }
    // Associate with Second entity
    public Context2 : ObjectContext
    {
        prop IDbSet<B> BDbSet{ get; set; }
        ...
    }
    public void ChangeDb(string dbName)
    {
        Context1 context = new Context1();
        context.ChangeDatabase(dbName);
    }

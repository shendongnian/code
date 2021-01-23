    // NOTE: this is an expression, not a method
    private static Expression<Func<ClientDataAccessLayer.Client, BusinessLogic.Client>> Convert =
        x => new BusinessLogic.Client // NOTE: initializer, not a constructor
        {
            Id = x.Id,
            ...
        };
    public IQueryable<BusinessLogic.Client> Clients()
    {
        this.MainDB.Clients.Select(Convert);
    }

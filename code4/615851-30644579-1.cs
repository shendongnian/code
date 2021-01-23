    [ActionName("builtin")]
    public IEnumerable<string> Get()
    {
        return this.Repository.GetAll();
    }

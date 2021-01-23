    public IEnumerable<Content> Get()
    {
        using (FooDataContext db = new FooDataContext())
        {
            return db.Content.ToList();
        }
    }

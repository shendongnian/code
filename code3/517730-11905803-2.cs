    public IEnumerable<Content> Get()
    {
        using (FooDataContext db = new FooDataContext())
        {
            return db.Content
                     .Select(c => new Content { Name = c.Name,
                                                Foo =  c.Foo,
                                                // etc
                             })
                     .ToList();
        }
    }

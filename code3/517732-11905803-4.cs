    public IEnumerable<Content> Get()
    {
        using (FooDataContext db = new FooDataContext())
        {
            return db.Content
                     .ToList()
                     .Select(c => new Content { Name = c.Name,
                                                Foo =  c.Foo,
                                                // etc
                             });
        }
    }

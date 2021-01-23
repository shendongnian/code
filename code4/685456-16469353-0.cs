    [HttpGet]
    public Person FindById(string id)
    {
        // We're concerned someone might call FindById and fish for non-Person objects.
        if (!id.StartsWith("people/"))
        {
            throw new ArgumentException("Naughty!");
        }
    
        using (IDocumentSession session = _docStore.OpenSession())
        {
            return session.Load<Person>(id);
        }
    }

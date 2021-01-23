    [HttpGet]
    public IEnumerable<Contact> GetPeople()
    {
        return from p in _contextProvider.Context.People
               select new Contact {
                   Id = p.Id,
                   LastName = p.LastName
               };
    }

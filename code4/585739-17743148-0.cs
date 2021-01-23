    public IQueryable<Person> GetPeople()
    {
        return DbContext.Set<Person>().Select(per => new {per.UserName, per.Email})                
    }
    public IQueryable<Person> GetPeople(int cityId)
    {
        return DbContext.Set<Person>().Where(p => p.CityID == cityId)
                   .Select(per => new {per.UserName, per.Email})                
    }

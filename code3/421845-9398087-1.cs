    public List<T> GetLookupList<T>()
    {
            PersonalLinksEntities dbContext = new PersonalLinksEntities();
            return dbContext .ToList<T>();
    
    }

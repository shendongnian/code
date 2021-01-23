    public IList<Entity> GetAll<Entity>()
         where Entity : class
    {
        return _session.CreateCriteria<Entity>().List<Entity>();
    }

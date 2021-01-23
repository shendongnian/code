    public class SearchCriteria
    {
        public string Name { get; set; }
        // ...more
    }
    public IEnumerable<Entity> FindAll(SearchCriteria criteria)
    {
        IQueryable<Entity> entities = _datasource.Entities; // replace with your L2S equivalent
        
        if (criteria.Name != null)
            entities = entities.Where(e => e.Name == criteria.Name);
        // ...more
        return entities;
    }

    class Collection<Entity>
    {
        ...
        public IQueryable<Entity> Query()
        {
            return this.cacheOne.Concat(this.cacheTwo.Values).AsQueryable();
        }
    }

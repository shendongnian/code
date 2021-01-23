    public void AssertReadWorks<T>(
        IRepository<T> repository, 
        T entity) where T : IEquatable<T>
    {
        entity = repository.GetAll().Single(x => entity.Equals(x);
    }

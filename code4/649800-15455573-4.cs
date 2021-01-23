    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(object id);
        void Save(T item);
        void Delete(T item);
    }

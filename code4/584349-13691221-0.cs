    public interface IRepository
    {
        IQueryable<T> GetQueryable<T>();
        void Insert<T>(T item);
    }

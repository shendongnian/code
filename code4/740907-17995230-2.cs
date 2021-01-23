    // shared between repositories
    public interface IGenericRepository<T> 
    {
        T CreateNew();
        void Delete( T item );
        void Update( T item );
        void Insert( T item );
        IQueryable<T> Query { get; }
    }

    public interface IRepository<T> where T:IEntity
    {
        IQueryable<T> All { get; }
        T Find(object id);
        void Insert(T model);
    }

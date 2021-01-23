    public interface IRepository<TData> { }
    public clss GenericRepository<TData> : IRepository<TData>
    { 
        public GenericRepository(TData data) { }
    }

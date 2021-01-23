    public interface IUnitOfWork : IDisposable
    {
        void Complete();
        TRepository GetRepository<TRepository, TItem>()
            where TRepository : IRepository<TItem>
            where TItem : class;
    }

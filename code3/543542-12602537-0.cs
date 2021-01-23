    public interface IRepository<T, in TId> where T : IEntity
    {
        T GetById(TId id);
        T Persist(T entity);
        void Remove(TId id);
    }
    [ContractClassFor(typeof(IRepository<,>))]
    internal abstract class IRepositoryContracts<T, TId> : IRepository<T, TId> where T : IEntity
    {
        public T GetById(TId id)
        {
            Contract.Requires(id != null);
            return default(T);
        }
        public T Persist(T entity)
        {
 	        Contract.Requires(entity != null);
            return default(T);
        }
        public void Remove(TId id)
        {
 	        Contract.Requires(id != null);
        }
    }

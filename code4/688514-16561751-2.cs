    public class BaseEntity
    {
        public int Id { get; set; }
        // ...
    }
    public interface IRepostory<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity Get(int id);
        void Save(TEntity entity);
        // ...
    }
    public class BaseService<TEntity, TCollectionRequest> : Service
        where TEntity : BaseEntity
    {
        public IRepository<TEntity> Repository { get; set; }
        public virtual object Get(TEntity request)
        {
            return Repository.Get(request.Id);
        }
        public virtual object Get(TCollectionRequest request)
        {
            return Repository.GetAll();
        }
        public virtual object Post(TEntity request)
        {
            Repository.Save(request);
            return request;
        }
        public virtual object Put(TEntity request)
        {
            // ...
        }
        // ...
    }

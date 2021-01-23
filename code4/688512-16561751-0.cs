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
        public virtual object Get(TEntity request)
        {
            var repo = this.ResolveService<IRepostory<TEntity>>();
            return repo.Get(request.Id);
        }
        public virtual object Get(TCollectionRequest request)
        {
            var repo = this.ResolveService<IRepostory<TEntity>>();
            return repo.GetAll();
        }
        public virtual object Post(TEntity request)
        {
            var repo = this.ResolveService<IRepostory<TEntity>>();
            repo.Save(request);
            return request;
        }
        public virtual object Put(TEntity request)
        {
            // ...
        }
        // ...
    }

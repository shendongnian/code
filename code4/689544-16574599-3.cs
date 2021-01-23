    public class Repository : Component, IRepository
    {
        protected DbContext session;
        {
            get
            {
                if (session == null)
                    throw new InvalidOperationException("A session IUnitOfWork do repositório não está instanciada.");
                return (session as IUnitOfWork);
            }
        }
        public virtual DbContext Context
        {
            get
            {
                return session;
            }
        }
        public Repository()
            : base()
        {
        }
		
        public Repository(DbContext instance)
            : this(instance as IUnitOfWork)
        {
        
        #endregion
        public IList<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return session.Set<TEntity>().ToList();
        }
        
        public bool Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (!IsValid(entity))
                return false;
            try
            {
                session.Set(typeof(TEntity)).Add(entity);
                return session.Entry(entity).GetValidationResult().IsValid;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        } ...

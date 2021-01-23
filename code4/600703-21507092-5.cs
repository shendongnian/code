    public class BaseDomainService<T> where T : class
    {
        protected readonly DbContext _dbContext;
    
        public BaseDomainService(IUnitOfWork uow)
        {
            _dbContext = (DbContext)uow;
        }
        .....
        public static EntityState ConvertState(BaseEntity.States state)
        {
            switch (state)
            {
                case BaseEntity.States.Added:
                    return EntityState.Added;
                case BaseEntity.States.Modified:
                    return EntityState.Modified;
                case BaseEntity.States.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }    
    
        public void ApplyChanges<TEntity>(TEntity root) where TEntity : BaseEntity
        {
            _dbContext.Set<TEntity>().Add(root);
            foreach (var entry in _dbContext.ChangeTracker
            .Entries<BaseEntity>())
            {
                if (FoundAnEntityWithSameKeyInDbContext<TEntity>(entry))
                    entry.State = EntityState.Detached;
                else
                {
                    BaseEntity stateInfo = entry.Entity;
                    if (stateInfo.MustDelete == true)
                        entry.State = EntityState.Detached;
                    else
                        entry.State = ConvertState(stateInfo.State);
                }
            }
        }
        private bool FoundAnEntityWithSameKeyInDbContext<TEntity>(DbEntityEntry<BaseEntity> entry) where TEntity : BaseEntity
        {
            var tmp = _dbContext.ChangeTracker.Entries<BaseEntity>().Count(t => t.Entity.Id == entry.Entity.Id && t.Entity.Id != 0 && t.Entity.GetType() == entry.Entity.GetType());
            if (tmp > 1)
                return true;
            return false;
        }
    }

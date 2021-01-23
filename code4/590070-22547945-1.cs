    public class NamedRepository<TEntity> : GenericRepository<TEntity>
        where TEntity : class, IStringName
    {
        public NamedRepository(ReportsDirectoryEntities context) : base(context)
        {
        }
        
        public virtual TEntity GetByName(string name)
        {
            return (from e in base.context.Set<TEntity>()
                    where e.Name == name
                    select e).SingleOrDefault();
        }
    }

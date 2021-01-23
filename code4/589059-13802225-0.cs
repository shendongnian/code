    public abstract class Repository<TEntity> where TEntity : Entity
    {
        protected virtual Expression<Func<TEntity, bool>> Filter { get { return null; } }
    
        public TEntity[] GetAll()
        {
            if (this.Filter == null)
            {
                return _context.Set<TEntity>().ToArray();
            }
            else
            {
                return _context.Set<TEntity>().Where(this.Filter).ToArray();
            }
        }
    }
    public class ArchiveRepository : Repository<Archive>
    {
        public ArchiveRepository()
        {
            this.Filter = archive => !archive.IsDeleted;
        }
    }

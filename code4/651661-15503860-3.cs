    public class EntityRepository<E> : IRepository<E> where E : class
    {
        public virtual Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
    
    public abstract class ApplicationBCBase<E> : IEntityBC<E>
    {
        public virtual Task Save()
        {
            return repository.Save();
        }
    }

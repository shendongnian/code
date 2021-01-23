    public interface IDbEntity: IEntity
    {
    }
    public class DbRepository<T> : IRepository<T> where T:IDbEntity
    {
        public IQueryable<T> All { get; private set; }
        public T Find(object id)
        {
            throw new NotImplementedException();
        }
        public void Insert(T model)
        {
            throw new NotImplementedException();
        }
    }

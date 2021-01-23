    public interface IRepository {
       DataRow Get(int key);
    }
    
    public abstract class Repository<T> : IRepository<T>, IRepository
        where T : DataRow
    {
       public abstract T Get(int key);
       DataRow IRepository.Get(int key) {
           return this.Get(key);
       }
    }

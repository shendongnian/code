    interface IRepository {
        IList Get();
    }
    public class Repository <TKey, TEntity> : IRepository {
        IList IRepository.Get() {
            return Get();
        }
        // your existing code here
    }

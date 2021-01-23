    public interface IDataContext<T>
    {
       // Query
       IList<T> GetAll<T>();
       IList<T> GetByCriteria<T>(Query query);
       T GetByID<T>(string id);
       // CUD
       void Add(T item);
       void Delete(T item);
       void Save(T item);
    }

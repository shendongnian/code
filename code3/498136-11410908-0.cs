    public interface IPersistence
    {
        TData GetData<TData, TKey>(TKey Key) where TData : class, new();
    }
    public interface IDbPersistence
    {
        TData GetData<TData, TKey>(TKey Key) where TData : class, IEntity, new();
    }
    public class DbPersistence : IPersistence, IDbPersistence
    {
        TData IPersistence.GetData<TData, TKey>(TKey Key)
        {
            // fancy data access code
        }
        TData GetData<TData, TKey>(TKey Key)
        {
            return ((IPersistence)this).GetData<TData, TKey>(Key);
        }
    }

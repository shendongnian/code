    public interface IDataContext : IDisposable
    {
       int SaveChanges();
    }
    
    //Generic interface for a read-only repository
    public interface IReadOnlyRepository<T> : IDisposable where T : class
    
    //Generic interface for a read/write repository
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    
    //Basic implementation for a read-only repository
    public abstract class BaseReadOnlyRepository<C, T> : IReadOnlyRepository<T>
        where T : class
        where C : IDataContext
    {
    }
    
    //Basic implementation for a read/write repository
    public abstract class BaseRepository<C, T> : IRepository<T>
        where T : class
        where C : IDataContext
    {
    }
    public interfaces IAccountContext : IDataContext
    {
       //other methods
    }

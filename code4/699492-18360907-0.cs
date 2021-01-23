    public interface IObjectFactory
    {
        T CreateOrReuse<T>() where T : class, new();
        T CreateOrReuse<T>(string key) where T : class, new();
        T CreateOrReuse<T>(string key, params object[] args) where T : class;
    }
    public class ThreadObjectFactory : IObjectFactory
    {
        // implementation to create and store into the Thread Data
    }
    public class HttpSessionObjectFactory : IObjectFactory
    {
        // implementation to create and store into the current session
    }

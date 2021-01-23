    abstract public class RepositoryBase<T>
        where T : RepositoryBase<T>, new()
    {
        public static readonly T Instance = new T();
    }
    public class SpecificRepository : RepositoryBase<SpecificRepository>
    {
    }

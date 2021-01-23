    public class RepositoryFactory
    {
        public static IRepository<T> CreateRepository<T>()
        {
            IRepository<T> repo = null;
            Type forType = typeof(T);
    
            if (forType == typeof(Foo))
            {
                repo = new FooRepo() as IRepository<T>;
            }
            else if (forType == typeof(Bar))
            {
                repo = new BarRepo() as IRepository<T>;
            }
    
            return repo;
        }
    }

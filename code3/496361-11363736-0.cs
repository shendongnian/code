    public interface IoCContainer
    {
        object GetInstance(Type serviceType);
        object GetInstance(Type serviceType, string key);
        IEnumerable<object> GetAllInstances(Type serviceType);
        T GetInstance<T>();
        T GetInstance<T>(string key);
        IEnumerable<T> GetAllInstances<T>();
    }
    public static class IoCContainerFactory
    {
        private static IoCContainer current;
        public static IoCContainer Current
        {
            get
            {
                if (current == null)
                    throw new DomainException("IoC Container Not Initialized.  This application must call a bootstrap method in an IoC implementation project.");
                return current;
            }
        }
        public static void Initialize(IoCContainer container)
        {
            current = container;
        }
    }

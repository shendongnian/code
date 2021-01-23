    public static class ServiceLocatorExtensions
    {    
        public static T GetService<T>(IServiceLocator loc) {
            return (T)loc.GetService(typeof(T));
        }
    }

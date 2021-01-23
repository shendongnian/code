    public class ParentClass<T> where T : class, new() {
        private static T _instance = null;
        private static readonly object _locker = new object();
        public static T GetObject() {
            if (_instance == null) {
                lock (_locker) {
                    if (_instance == null) {
                        return new T();
                    }
                    return _instance;
                }
            }
        }
    }

    public class Singleton<T> where T : new()
    {
        public static Singleton<T> Current {
            get;
            private set;
        }
        internal Singleton() {
            T t = new T();
            // Do stuff with T
        }
        public String Name {
            get;
            set;
        }
    }

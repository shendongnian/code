    public class Singleton<T> where T : new()
    {
        public static Singleton<T> Current {
            get;
            private set;
        }
        internal Singleton() : this(new T()) {
        }
        private Singleton(T t) {
            Current = this;
            // Do whatever you need to with T
        }        
        public String Name {
            get;
            set;
        }
    }

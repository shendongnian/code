    public abstract class SessionBase<T> where T : new()
    {
        private static string Key
        {
            get { return typeof(SessionBase<T>).FullName; }
        }
        public static T Current
        {
            get
            {
                var instance = HttpContext.Current.Session[Key] as T;
                // if you never want to return a null value
                if (instance == null)
                {
                    HttpContext.Current.Session[Key] = instance = new T();
                }
                return instance;
            }
            set
            {
                HttpContext.Current.Session[Key] = value;
            }
        }
        public static void Clear()
        {
            var instance = HttpContext.Current.Session[Key] as T;
            if (instance != null)
            {
                HttpContext.Current.Session[Key] = null;
            }
        }
    }

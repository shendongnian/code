    public class SingletonBase<T> 
        where T : new(), SingletonBase<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new T();
                return _instance;
            }   
        }
    }

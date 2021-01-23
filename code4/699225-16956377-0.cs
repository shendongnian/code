    public static class ListCreator
    {
        private static readonly Dictionary<Type, Func<object>> _Creators;
        static ListCreator()
        {
            _Creators = new Dictionary<Type, Func<object>>();
            InitializeDefaultCreators();
        }
        public static List<T> Create<T>()
        {
            Func<object> creator;
            if (!_Creators.TryGetValue(typeof(T), out creator))
            {
                throw new InvalidOperationException("No creator available for type " + typeof(T).FullName);
            }
            return (List<T>)creator();
        }
        public static void Register<T>(Func<List<T>> creator)
        {
            _Creators.Add(typeof(T), creator);
        }
        public static void Register(Type type, Func<object> creator)
        {
            _Creators.Add(type, creator);
        }
        public static bool Unregister<T>()
        {
            return _Creators.Remove(typeof(T));
        }
        public static bool Unregister(Type type)
        {
            return _Creators.Remove(type);
        }
        private static void InitializeDefaultCreators()
        {
            Register(MyDoubleListCreator);
            Register(typeof(int), () => Enumerable.Range(1, 15).ToList());
        }
        private static List<double> MyDoubleListCreator()
        {
            return Enumerable.Range(1, 10).Select(Convert.ToDouble).Select(val => val + 0.3).ToList();
        }
    }

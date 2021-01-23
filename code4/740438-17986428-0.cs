    namespace Helpers.DesignPatterns
    {
    public class Singleton<T> where T : class
    {
        private static volatile T _instance;
        private static object _syncRoot = new Object();
        protected Singleton()
        {
        }
        private static T CreateInstance()
        {
            ConstructorInfo cInfo = typeof(T).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]);
            return (T)cInfo.Invoke(null);
        }
        /// <summary>
        /// Точка входа синглтона
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = CreateInstance();
                    }
                }
                return _instance;
            }
        }
      }
    }

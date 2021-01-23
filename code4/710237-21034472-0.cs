    public static class Singlett<Param,T>
       where T : class
    {
        static volatile Lazy<Func<Param, T>> _instance;
        static object _lock = new object();
        static Singlett()
        {
        }
        public static Func<Param, T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Lazy<Func<Param, T>>(() =>
                    {
                        lock (Singlett<Param,T>._lock)
                        {
                            try
                            {
                                ConstructorInfo constructor = null;
                                Type[] methodArgs = { typeof(Param) };                                
                                constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, methodArgs, null);// Binding flags excludes public constructors.
                                if (constructor == null)
                                {
                                    constructor = typeof(T).GetConstructor(BindingFlags.Public, null, methodArgs, null);
                                    if (constructor == null)
                                        return delegate(Param o) { return (T)Activator.CreateInstance(typeof(T), new object[] { o }); };
                                }
                                return delegate(Param o) { return (T)constructor.Invoke(new object[] { o }); };
                            }
                            catch (Exception exception)
                            {
                                throw exception;
                            }
                        }
                    });
                }
                return _instance.Value;
            }
        }
    }

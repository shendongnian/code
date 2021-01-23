    class LogUtility : ILogUtility
    {
        private Type classType;
        public LogUtil(object o)
            : this(o.GetType())
        {
        }
        
        public LogUtil(Type t)
        {
            this.classType = t;
        }
        
        public static LogUtil Create<T>()
        {
            return new LogUtil(typeof(T));
        }
        
        public void Log(string message)
        {
            Console.WriteLine("logging coming from class {0} - message {1} " , this.classType, message);
        }
    }

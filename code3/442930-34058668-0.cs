    public sealed class SingletonType
    {
        #region thread-safe singletone
        private static object _lock = new object();
        private SingletonType() { }
        public static SingletonType SingletonInstance
        {
            get
            {
                if (CallContext.GetData(key) == null)
                {
                    lock (_lock)
                    {
                        if (CallContext.GetData(key) == null)
                            CallContext.SetData(key, new SingletonType());
                    }
                }
                return CallContext.GetData(key) as SingletonType;
            }
        }
        #endregion
        //
        //
        // SingletoneType members
        //
        //
    }

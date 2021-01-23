    class PseudoSingleton<T>
        where T : new()
    {
        private readonly object _lock = new object();
        private T _instance;
    
        public T Instance
        {
            get
            {
                lock (this._lock)
                {
                    if (this._instance != null)
                    {
                        this._instance = new T();
                    }
                    return this._instance;
                }
            }
        }
        public void Reset()
        {
            lock (this._lock)
            {
                this._instance = null;
            }
        }
    }

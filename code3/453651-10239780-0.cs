    public static Singleton GetInstance()
        {
            lock (typeof(Singleton))
            {
                instance = new Singleton();
            }
            return instance;
        }

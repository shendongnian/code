    class MyCache : IDisposable
    {
        public void Dispose()
        {
            var tmp = conn;
            conn = null;
            if (tmp != null)
            {
                tmp.Close(true);
                tmp.Dispose();
            }
        }
        private RedisConnection conn;
        private readonly int db;
        public MyCache(string configuration = "127.0.0.1:6379", int db = 0)
        {
            conn = ConnectionUtils.Connect(configuration);
            this.db = db;
            if (conn == null) throw new ArgumentException("It was not possible to connect to redis", "configuration");
        }
        public byte[] Get(string key)
        {
            return conn.Wait(conn.Strings.Get(db, key));
        }
        public void Set(string key, byte[] value, int timeoutSeconds = 60)
        {
            conn.Strings.Set(db, key, value, timeoutSeconds);
        }
    }

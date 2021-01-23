    public static class SocketStore
    {
        static readonly Dictionary<string, Socket> socketStore
              = new Dictionary<string, Socket>();
        public static string Add(Socket socket)
        {
            if(socket == null) throw new ArgumentNullException("socket");
            string newKey = Guid.NewGuid().ToString();
            lock(socketStore) {
                socketStore.Add(newKey, socket);
            }
            return newKey;
        }
        public static Socket Get(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            Socket result;
            lock (socketStore)
            {
                if (!socketStore.TryGetValue(key, out result)) result = null;
            }
            return result;
        }
    }

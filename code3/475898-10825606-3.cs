    public static class Manager
    {
        private static IDictionary<string, IDisposable> runningOperations;
    
        static Manager()
        {
            runningOperations = new Dictionary<string, IDisposable>();
        }
    
        public static void Add(string key, IDisposable runningOperation)
        {
            if (runningOperations.ContainsKey(key))
            {
                throw new ArgumentOutOfRangeException("key");
            }
    
            runningOperations.Add(key, runningOperation);
        }
    
        public static void Cancel(string key)
        {
            IDisposable value = null;
            if (runningOperations.TryGetValue(key, out value))
            {
                value.Dispose();
                runningOperations.Remove(key);
            }
        }

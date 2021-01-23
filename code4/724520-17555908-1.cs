    public class ResourceAccessorClass
    {
        private object _lockObject = new object();
        public void SafeAccess()
        {
            lock (_lockObject)
            {
                // Access thread-sensitive resources.
            }
        }
    }

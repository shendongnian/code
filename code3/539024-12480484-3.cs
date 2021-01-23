    public static class Globals
    {
        ...
        public static int Version { get {return _version; } }
        private static int _version;
        public static void NeedRefresh()
        {
            Interlocked.Increment(ref _version);
        }
    }
    public class CacheItem<T>
    {
        public int Version {get; private set; }
        
        ...
        public void Load(string key)
        {
            Version = Globals.Version;
            List<T> records = new List<T>();
            // Filling records from DB filtered on key
            // ...
            _records = records;
        }
    }

    public class Dictionary<TKey, TValue> : ...
    {
        private int[] buckets; //4 bytes for x86, 8 for x64
        private Dictionary<TKey, TValue>.Entry[] entries; //4 bytes for x86, 8 for x64
        private int count; //4 bytes
        private int version; //4 bytes
        private int freeList; //4 bytes
        private int freeCount; //4 bytes
        private IEqualityComparer<TKey> comparer; //4 bytes for x86, 8 for x64
        private Dictionary<TKey, TValue>.KeyCollection keys; //4 bytes for x86, 8 for x64
        private Dictionary<TKey, TValue>.ValueCollection values; //4 bytes for x86, 8 for x64
        private object _syncRoot; //4 bytes for x86, 8 for x64
        private const string VersionName = "Version"; //one per type
        private const string HashSizeName = "HashSize"; //one per type
        private const string KeyValuePairsName = "KeyValuePairs"; //one per type
        private const string ComparerName = "Comparer"; //one per type
    }

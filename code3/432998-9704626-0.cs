    sealed class ThreadSafeHashTable
    {
        private readonly HashTable hashTable = new HashTable();
        public void Add(object key, object value)
        {
            lock(this.hashTable)
            {
                ...

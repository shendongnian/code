        private static readonly ConcurrentDictionary<int, PrivateClass> SomeClasses =
            new ConcurrentDictionary<int, PrivateClass>();
        public SomeClass(int cachedInstanceId)
        {
            _privateClass = SomeClasses.GetOrAdd(cachedInstanceId, (key) => new Lazy<PrivateClass>(() => new PrivateClass(key)).Value);
        }

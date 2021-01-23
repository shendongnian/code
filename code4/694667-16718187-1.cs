    public sealed class Multiton
    {
        private static readonly 
            Lazy<ConcurrentDictionary<object, Lazy<Multiton>>> dic =
                new Lazy<ConcurrentDictionary<object, Lazy<Multiton>>>(
                   () => new ConcurrentDictionary<object, Lazy<Multiton>>());
        public static Multiton Instance(object key)
        {
            var instance = dic.Value.GetOrAdd(
                key,
                new Lazy<Multiton>(() => new Multiton()));
            return instance.Value;
        }
        private Multiton()
        {
        }
    }

    public sealed class Multiton
    {
        private static readonly Lazy<ConcurrentDictionary<object, Multiton>> dic =
           new Lazy<ConcurrentDictionary<object, Multiton>>(
               () => new ConcurrentDictionary<object, Multiton>());
        public static Multiton Instance(object key)
        {
            var instance = dic.Value.GetOrAdd(
                key,
                new Multiton());
            return instance;
        }
        private Multiton()
        {
        }
    }
